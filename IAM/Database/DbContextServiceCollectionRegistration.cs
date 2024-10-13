using System;
using Microsoft.EntityFrameworkCore;

namespace IAM.Database;

public static class DbContextServiceCollectionRegistration
{
    public static IServiceCollection AddMysqlDatabaseService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseMySQL(configuration.GetConnectionString("DefaultConnection"))
        );

        return services;
    }
}
