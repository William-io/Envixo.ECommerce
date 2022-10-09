namespace Envixo.Ecommerce.App.Infrastructure.Data;

public class DataContext : DbContext
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Ignore<Notification>();

        builder.Entity<Product>()
            .Property(p => p.Title).IsRequired();
        builder.Entity<Product>()
            .Property(p => p.Description).HasMaxLength(255);
        builder.Entity<Product>()
            .Property(p => p.Price).HasColumnType("decimal(10,2)").IsRequired();
        builder.Entity<Product>()
            .Property(p => p.PromotionalPrice).HasColumnType("decimal(10,2)").IsRequired();
        builder.Entity<Category>()
            .Property(c => c.Name).IsRequired();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        configuration.Properties<string>()
            .HaveMaxLength(100);
    }
}