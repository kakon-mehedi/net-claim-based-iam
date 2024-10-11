using System;

namespace IAM.ServicesRegistrations;

public static class ApplicationMiddlewareRegistrations
{
    public static IApplicationBuilder AddApplicationMiddlewares(this IApplicationBuilder app, IHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        return app;
    }
}
