using System;
using IAM.Database;
using IAM.Models;
using Microsoft.AspNetCore.Identity;

namespace IAM.ServicesRegistrations;

public static class ApplicationThirdPartyServicesRegistrations
{
    public static IServiceCollection AddThirdPartyServices(this IServiceCollection services)
    {
        // Calling different functions which extend the IServiceCollection type 
        services.AddIdentity<User, IdentityRole>()
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

        return services;
    }
}
