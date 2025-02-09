using System;
using Microsoft.EntityFrameworkCore;

namespace IAM.Database;

public static class DbContextServiceCollectionRegistration
{
    public static IServiceCollection AddMysqlDatabaseService(this IServiceCollection services,
        IConfiguration configuration)
    {
        string? mySqlConnectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");

        if (string.IsNullOrEmpty(mySqlConnectionString))
        {
            throw new ApplicationException("The connection string is empty.");
        }

        services.AddDbContext<ApplicationDbContext>(
            options => options.UseMySQL(mySqlConnectionString)
        );

        return services;
    }
}