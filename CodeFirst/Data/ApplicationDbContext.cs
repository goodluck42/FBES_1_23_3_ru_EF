using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;

/*
 * MSSQLServer: Server=localhost;Database=master;Trusted_Connection=True;TrustServerCertificate=True;
SQLEXPRESS (в академии): Server=.\SQLEXPRESS;Database=master;Trusted_Connection=True; User Id=admin; Password=admin
 */

namespace CodeFirst.Data;

public class ApplicationDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public ApplicationDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration["MSSqlServerConnectionString"]);
    }

    public DbSet<Account> Accounts { get; set; }
}