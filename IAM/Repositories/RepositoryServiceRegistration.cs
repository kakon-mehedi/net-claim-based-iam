using System;
using IAM.Repositories.Implementations;

namespace IAM.Repositories;

public static class RepositoryServiceRegistration
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepositoryService<>), typeof(RepositoryService<>));

        return services;
    }
}
