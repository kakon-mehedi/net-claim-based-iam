using System;
using IAM.Database;
using IAM.Models;
using Microsoft.AspNetCore.Identity;

namespace IAM.ServicesRegistrations;

public static class ApplicationThirdPartyServicesRegistrations
{
    public static IServiceCollection AddThirdPartyServices(this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole>()
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

        return services;
    }
}
