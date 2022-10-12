namespace Envixo.Ecommerce.App.Settings;

public static class SwaggerSetup
{
    public static IServiceCollection AddSwaggerSetup(this IServiceCollection services) =>
        services.AddSwaggerGen(opt => opt.EnableAnnotations());

    public static WebApplication UseSwaggerSetup(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}