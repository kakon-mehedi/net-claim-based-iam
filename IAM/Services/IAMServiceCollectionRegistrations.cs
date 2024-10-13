using System;
using IAM.Models;
using IAM.Repositories;
using IAM.Services.Implementations;
using Microsoft.AspNetCore.Identity;

namespace IAM.Services;

public static class IamServiceCollectionRegistrations
{
    public static IServiceCollection AddIamServices(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        
        return services;
    }
}
