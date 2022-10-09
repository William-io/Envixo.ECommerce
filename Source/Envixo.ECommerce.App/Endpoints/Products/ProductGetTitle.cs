namespace Envixo.Ecommerce.App.Endpoints.Products;

public class ProductGetTitle
{
    public static string Template => "/products/{title}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    [SwaggerOperation(
          Summary = "Obter produto pelo [Nome]",
          Description = "Precisa-se inserir o nome do produto",
          OperationId = nameof(ProductGetTitle),
          Tags = new[] { "Product" })]
    public static IResult Action([FromRoute] string title, DataContext context)
    {

        var filterProductTitle = context.Products.Where(c => c.Title == title).FirstOrDefault();

        if (filterProductTitle == null)
            return Results.NotFound();

        if (!filterProductTitle.IsValid)
            return Results.ValidationProblem(filterProductTitle.Notifications.ConvertToProblemDetails());

        var products = context.Products.Include(p => p.Category).Where(p => p.Title == title).ToList();

        var results = products.Select(p => new ProductResponse(p.Id, p.Title, p.Description, p.MidiaUrl, p.Status, p.Price, p.PromotionalPrice, p.Tags, p.Category.Name, p.Category.Id));

        return Results.Ok(products);
    }
}