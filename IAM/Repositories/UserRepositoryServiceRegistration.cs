using System;

namespace IAM.Repositories;

public static class UserRepositoryServiceRegistration
{
    public static IServiceCollection AddUserRepositoryService(this IServiceCollection services)
    {
        services.AddTransient<IUserRepositoryService, UserRepositoryService>();
        return services;
    }
}
