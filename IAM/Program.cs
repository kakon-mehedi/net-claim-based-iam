using IAM.ServicesRegistrations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();

var app = builder.Build();

app.AddApplicationMiddlewares(app.Environment);

app.MapControllers();

app.Run();
