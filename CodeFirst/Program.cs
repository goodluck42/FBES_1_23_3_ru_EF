using CodeFirst.Data;
using CodeFirst.Entities;
using CodeFirst.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configurationBuilder = new ConfigurationBuilder();

configurationBuilder.AddJsonFile("config.json");

var serviceCollection = new ServiceCollection();

serviceCollection.AddSingleton<IConfiguration>(provider => configurationBuilder.Build());
serviceCollection.AddDbContext<ApplicationDbContext>();
serviceCollection.AddTransient<IAccountManager, DbAccountManager>();

var provider = serviceCollection.BuildServiceProvider();

{
    using var dbContext = provider.GetService<ApplicationDbContext>()!;

    // dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();
}

var accountManager = provider.GetService<IAccountManager>()!;

{
    var hasher = new SHA256Hasher();
    var account = new Account
    {
        Login = "Login2",
        IsBlocked = false,
        RegistrationDate = DateTime.Now,
        PasswordHash = hasher.HashString("zxcvbnm")
    };

    accountManager.Add(account);
}