using System;
using IAM.Services;

namespace IAM.ServicesRegistrations;

public static class ApplicationServiceRegistrations
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddBootstrapServices();
        services.AddIAMServices();
        return services;
    }


}
