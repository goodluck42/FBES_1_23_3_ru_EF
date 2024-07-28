using Inheritance.Data.Configurations;
using Inheritance.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;

/*
 * MSSQLServer: Server=localhost;Database=master;Trusted_Connection=True;TrustServerCertificate=True;
SQLEXPRESS (в академии): Server=.\SQLEXPRESS;Database=master;Trusted_Connection=True; User Id=admin; Password=admin
 */

namespace Inheritance.Data;

public class ApplicationDbContext : DbContext
{
	private readonly IConfiguration _configuration;

	public ApplicationDbContext(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.LogTo(message => File.AppendAllText("logs.txt", $"{message}\n"));
		optionsBuilder.UseSqlServer(_configuration["MSSqlServerConnectionString"]);
		optionsBuilder.UseLazyLoadingProxies();
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		//modelBuilder.ApplyConfiguration(typeof(AccountConfiguration), typeof(ProfileConfiguration));

		modelBuilder.ApplyConfiguration(AccountConfiguration.Instance);
		modelBuilder.ApplyConfiguration(ProfileConfiguration.Instance);
		modelBuilder.ApplyConfiguration(PostConfiguration.Instance);
		modelBuilder.ApplyConfiguration(PostProfileConfiguration.Instance);
		//
		// modelBuilder.Entity<Account>(builder =>
		// {
		// 	builder.ToTable("Accounts");
		// });
		//
		// modelBuilder.Entity<ModeratorAccount>(builder =>
		// {
		// 	builder.ToTable("ModeratorAccounts");
		// });
		//
		// modelBuilder.Entity<AdminAccount>(builder =>
		// {
		// 	builder.ToTable("AdminAccounts");
		// });

	}

	public DbSet<Account> Accounts { get; set; }
	public DbSet<ModeratorAccount> ModeratorAccounts { get; set; }
	public DbSet<AdminAccount> AdminAccounts { get; set; }
	public DbSet<Post> Posts { get; set; }
	public DbSet<Profile> Profiles { get; set; }
	public DbSet<PostProfile> PostProfiles { get; set; }
	public DbSet<ProfileSubscription> ProfileSubscriptions { get; set; }
}

/*
 * TPH - Table per Inheritance
 * TPT - Table per Type
 * TPC - Table per Concrete
 */