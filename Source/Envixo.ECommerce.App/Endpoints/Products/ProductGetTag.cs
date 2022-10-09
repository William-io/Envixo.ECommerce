namespace Envixo.Ecommerce.App.Endpoints.Products;

public class ProductGetTag
{
    public static string Template => "/products/{tag}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] string tag, DataContext context)
    {

        var filterTag = context.Products.Where(c => c.Tags == tag).FirstOrDefault();

        if (filterTag == null)
            return Results.NotFound();

        if (!filterTag.IsValid)
            return Results.ValidationProblem(filterTag.Notifications.ConvertToProblemDetails());

        var products = context.Products.Include(p => p.Category).Where(p => p.Tags == tag).ToList();

        var results = products.Select(p => new ProductResponse(p.Id, p.Title, p.Description, p.MidiaUrl, p.Status, p.Price, p.Tags, p.Category.Name));

        return Results.Ok(products);
    }
}