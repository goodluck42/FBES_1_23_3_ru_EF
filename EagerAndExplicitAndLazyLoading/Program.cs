global using EagerAndExplicitAndLazyLoading.Extensions;
using Microsoft.EntityFrameworkCore;
using EagerAndExplicitAndLazyLoading.Data;
using EagerAndExplicitAndLazyLoading.Entities;
using EagerAndExplicitAndLazyLoading.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configurationBuilder = new ConfigurationBuilder();

configurationBuilder.AddJsonFile("config.json");

var serviceCollection = new ServiceCollection();

serviceCollection.AddSingleton<IConfiguration>(provider => configurationBuilder.Build());
serviceCollection.AddDbContext<ApplicationDbContext>();

var provider = serviceCollection.BuildServiceProvider();

{
	using var scope = provider.CreateScope();
	using var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>()!;

	//dbContext.Database.EnsureDeleted();
	dbContext.Database.EnsureCreated();
}

#region InitialData

// #1
// {
// 	using var scope = provider.CreateScope();
// 	using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
// 	var hasher = new SHA256Hasher();
// 	var account = new Account
// 	{
// 		Login = "Login2",
// 		IsBlocked = false,
// 		RegistrationDate = DateTime.Now,
// 		PasswordHash = hasher.HashString("qwerty")
// 	};
//
// 	dbContext.Accounts.Add(account);
//
// 	dbContext.SaveChanges();
// }

// #2
// {
// 	using var scope = provider.CreateScope();
// 	using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//
// 	dbContext.Profiles.Add(new Profile
// 	{
// 		Followers = 42,
// 		Likes = 0,
// 		FirstName = "Aleksey",
// 		LastName = "Skiba",
// 		AccountId = 1
// 	});
// 	
// 	dbContext.Profiles.Add(new Profile
// 	{
// 		Followers = 100042,
// 		Likes = 9909999,
// 		FirstName = "Vadim",
// 		LastName = "Petrov",
// 		AccountId = 1
// 	});
//
// 	dbContext.SaveChanges();
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
// {
// 	using var scope = provider.CreateScope();
// 	using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//
// 	dbContext.Posts.Add(new Post
// 	{
// 		Likes = 10,
// 		Text = "Hey there",
// 		Reposts = 6
// 	});
//
// 	dbContext.SaveChanges();
// 	
// 	dbContext.PostProfiles.AddRange(new []
// 	{
// 		new PostProfile
// 		{
// 			PostId = 1,
// 			ProfileId = 1
// 		},
// 		new PostProfile
// 		{
// 			PostId = 1,
// 			ProfileId = 2
// 		}
// 	});
//
// 	dbContext.SaveChanges();
// }

#endregion


// # Eager Loading
// {
// 	using var scope = provider.CreateScope();
// 	using var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>()!;
//
// 	var accounts = dbContext.Accounts
// 		.Include(a => a.Profiles)
// 		.ThenInclude(p => p.ProfileSubscription);
//
// 	foreach (var account in accounts)
// 	{
// 		Console.WriteLine($"Login: {account.Login}");
// 		foreach (var profile in account.Profiles)
// 		{
// 			Console.WriteLine($"{profile.Id}");
// 			Console.WriteLine($"{profile.FirstName}");
//
// 			if (profile.ProfileSubscription != null)
// 			{
// 				Console.WriteLine($"SubscribeBegins: {profile.ProfileSubscription.SubscribeBegins}");
// 				Console.WriteLine($"SubscribeEnds: {profile.ProfileSubscription.SubscribeEnds}");
// 			}
// 		}
// 	}
// }

// # Explicit Loading
// {
// 	using var scope = provider.CreateScope();
// 	using var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>()!;
// 	var account = dbContext.Accounts.First(a => a.Id == 1);
// 	var entry = dbContext.Entry(account);
// 	var entryCollection = entry.Collection(a => a.Profiles);
//
// 	entryCollection.Load();
// 	
// 	foreach (var profile in account.Profiles)
// 	{
// 		var profileEntry = dbContext.Entry(profile);
// 		var referenceEntry = profileEntry.Reference(p => p.ProfileSubscription);
//
// 		referenceEntry.Load();
// 		
// 		Console.WriteLine($"profile {profile.Id}");
//
// 		if (profile.ProfileSubscription != null)
// 		{
// 			Console.WriteLine($"SubId: {profile.ProfileSubscription.Id}");
// 		}
// 	}
// }

// Lazy Loading
{
	using var scope = provider.CreateScope();
	using var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>()!;

	Account account = dbContext.Accounts.First(a => a.Id == 1);

	foreach (var profile in account.Profiles)
	{
		Console.WriteLine(profile.Id);
	}
	
	dbContext.ChangeTracker.LazyLoadingEnabled = false;
	
	// ...
	
	dbContext.ChangeTracker.LazyLoadingEnabled = true;
}