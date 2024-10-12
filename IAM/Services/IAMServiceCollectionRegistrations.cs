using System;
using IAM.Repositories;

namespace IAM.Services;

public static class IamServiceCollectionRegistrations
{
    public static IServiceCollection AddIamServices(this IServiceCollection services)
    {
        services.AddUserRepositoryService();
        return services;
    }
}
