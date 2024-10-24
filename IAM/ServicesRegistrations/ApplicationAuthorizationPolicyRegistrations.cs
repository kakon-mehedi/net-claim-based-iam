using System;
using System.Security.Claims;
using IAM.Services.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace IAM.ServicesRegistrations;

public static class ApplicationAuthorizationPolicyRegistrations
{
    public static IServiceCollection AddAuthorizationService(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy(AppPolicies.AdminPolicy, policy => policy.RequireClaim(AppClaims.Role, AppRoles.ADMIN));
           
            options.AddPolicy(AppPolicies.AdminOrHrPolicy, policy =>
            policy.RequireAssertion(context => context.User.HasClaim(c => c.Type == ClaimTypes.Role && (c.Value == AppRoles.ADMIN || c.Value == AppRoles.HR))));
        });

        return services;

    }
}
