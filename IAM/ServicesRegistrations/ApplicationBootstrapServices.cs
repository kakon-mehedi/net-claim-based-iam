using System;

namespace IAM.ServicesRegistrations;

public static class ApplicationBootstrapServices
{
    public static IServiceCollection AddBootstrapServices(this IServiceCollection services)
    {
        services
        .AddControllers()
        .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null); // Prevent api json response convert into small case
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddAuthentication();
        services.AddAuthorization();

        return services;
    }
}
