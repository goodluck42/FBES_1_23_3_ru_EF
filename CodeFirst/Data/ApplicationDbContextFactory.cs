using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CodeFirst.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder();

        configurationBuilder.AddJsonFile("config.json");

        var dbContext = new ApplicationDbContext(configurationBuilder.Build());

        return dbContext;
    }
}