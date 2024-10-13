using System;
using System.Security.Claims;

namespace IAM.ServicesRegistrations;

public static class ApplicationAuthorizationPolicyRegistrations
{
    public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("HRPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "HR"));
            options.AddPolicy("AdminPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
            options.AddPolicy("EmployeePolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Employee"));

            options.AddPolicy("AdminOrHRPolicy", policy =>
            policy.RequireAssertion(context => context.User.HasClaim(c => c.Type == ClaimTypes.Role && (c.Value == "Admin" || c.Value == "HR"))));
        });

        // Other services (e.g., Authentication)

        return services;

    }
}
