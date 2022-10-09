namespace Envixo.Ecommerce.App.Settings;

public static class SwaggerSetup
{
    public static IServiceCollection AddSwaggerSetup(this IServiceCollection services) =>
        services.AddSwaggerGen(opt => opt.EnableAnnotations());

    public static WebApplication UseSwaggerSetup(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        return app;
    }
}