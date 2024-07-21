global using Relationships.Extensions;
using Microsoft.EntityFrameworkCore;
using Relationships.Data;
using Relationships.Entities;
using Relationships.Services;
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
	using var scope = provider.CreateScope();
	using var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>()!;

	dbContext.Database.EnsureDeleted();
	dbContext.Database.EnsureCreated();
}

// #1
{
	using var scope = provider.CreateScope();
	using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
	var hasher = new SHA256Hasher();
	var account = new Account
	{
		Login = "Login2",
		IsBlocked = false,
		RegistrationDate = DateTime.Now,
		PasswordHash = hasher.HashString("qwerty")
	};

	dbContext.Accounts.Add(account);

	dbContext.SaveChanges();
}

// #2
{
	using var scope = provider.CreateScope();
	using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

	dbContext.Profiles.Add(new Profile
	{
		Followers = 42,
		Likes = 0,
		FirstName = "Aleksey",
		LastName = "Skiba",
		AccountId = 1
	});
	
	dbContext.Profiles.Add(new Profile
	{
		Followers = 100042,
		Likes = 9909999,
		FirstName = "Vadim",
		LastName = "Petrov",
		AccountId = 1
	});

	dbContext.SaveChanges();
}

// #3

// {
// 	using var scope = provider.CreateScope();
// 	using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//
// 	var account = dbContext.Accounts.Include(a => a.Profiles).First(a => a.Id == 1);
//
// 	Console.WriteLine(account.Login);
// 	Console.WriteLine(PasswordHasherHelper.ByteArrayToString(account.PasswordHash));
//
// 	foreach (var profile in account.Profiles)
// 	{
// 		Console.WriteLine($"#{profile.Id}");
// 		Console.WriteLine($"Followers: {profile.Followers}");
// 		Console.WriteLine($"Followers: {profile.Likes}");
// 		Console.WriteLine($"Followers: {profile.FirstName}");
// 		Console.WriteLine($"Followers: {profile.LastName}");
// 	}
// }

// #3.1

// {
// 	using var scope = provider.CreateScope();
// 	using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//
// 	var profile = dbContext.Profiles.Include(p => p.Account).First(a => a.AccountId == 1);
//
// 	Console.WriteLine($"#{profile.Id}");
// 	Console.WriteLine($"Followers: {profile.Followers}");
// 	Console.WriteLine($"Followers: {profile.Likes}");
// 	Console.WriteLine($"Followers: {profile.FirstName}");
// 	Console.WriteLine($"Followers: {profile.LastName}");
//
// 	Console.WriteLine(profile.Account.Id);
// 	Console.WriteLine(profile.Account.Login);
// 	Console.WriteLine(PasswordHasherHelper.ByteArrayToString(profile.Account.PasswordHash));
// }

// #4
// {
// 	using var scope = provider.CreateScope();
// 	using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//
// 	dbContext.ProfileSubscriptions.Add(new ProfileSubscription
// 	{
// 		ProfileId = 1,
// 		SubscribeBegins = DateTime.Now,
// 		SubscribeEnds = DateTime.Now.AddYears(1)
// 	});
//
// 	dbContext.SaveChanges();
// }

// #5
{
	using var scope = provider.CreateScope();
	using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

	dbContext.Posts.Add(new Post
	{
		Likes = 10,
		Text = "Hey there",
		Reposts = 6
	});

	dbContext.SaveChanges();
	
	dbContext.PostProfiles.AddRange(new []
	{
		new PostProfile
		{
			PostId = 1,
			ProfileId = 1
		},
		new PostProfile
		{
			PostId = 1,
			ProfileId = 2
		}
	});

	dbContext.SaveChanges();

}