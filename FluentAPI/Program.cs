﻿global using FluentAPI.Extensions;

using FluentAPI.Data;
using FluentAPI.Entities;
using FluentAPI.Services;
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
        PasswordHash = hasher.HashString("qwerty")
    };

    accountManager.Add(account);
}