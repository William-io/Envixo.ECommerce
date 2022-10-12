namespace Envixo.Ecommerce.App.Settings;

public static class AppExtensions
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
    }

}