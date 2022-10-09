namespace Envixo.Ecommerce.App.Endpoints.Products;

public class ProductGetAll
{
    public static string Template => "/products";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(DataContext context)
    {
        var products = context.Products.Include(p => p.Category).OrderBy(p => p.Title).ToList();
        var results = products.Select(p => new ProductResponse(p.Id, p.Title, p.Description, p.MidiaUrl, p.Status, p.Price, p.Tags, p.Category.Name));
        return Results.Ok(results);
    }
}