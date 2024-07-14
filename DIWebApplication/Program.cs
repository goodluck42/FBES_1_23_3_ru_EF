using DIWebApplication.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

IServiceCollection serviceCollection = builder.Services; // new ServiceCollection();

// serviceCollection.AddSingleton<ICounterService, CounterService>();
// serviceCollection.AddTransient<ICounterService, CounterService>();

serviceCollection.AddTransient<ICounterFormatter, CounterFormatter>();
serviceCollection.AddScoped<ICounterService, CounterService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();