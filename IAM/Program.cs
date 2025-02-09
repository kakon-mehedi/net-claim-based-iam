using IAM.ServicesRegistrations;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args); 

builder.Services.AddApplicationServices(builder.Configuration);

WebApplication app = builder.Build();

app.AddApplicationMiddlewares(app.Environment);

app.MapControllers();

app.Run();