using System;
using IAM.Database;
using IAM.Repositories;
using IAM.Services;

namespace IAM.ServicesRegistrations;

public static class ApplicationServiceRegistrations
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddBootstrapServices();
        services.AddMysqlDatabaseService(configuration);
        services.AddRepositoryServices();
        
        services.AddIamServices();
        services.AddThirdPartyServices();
        return services;
    }
}
