using API;
using Application;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");

    app.UseAuthentication();
    app.UseAuthorization();
    
    app.MapControllers();
    app.Run();
}