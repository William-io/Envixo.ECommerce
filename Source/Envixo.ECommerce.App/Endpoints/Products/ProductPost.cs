namespace Envixo.Ecommerce.App.Endpoints.Products;

public class ProductPost
{
    public static string Template => "/products";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    [SwaggerOperation(
          Summary = "Criar um produto",
          Description = "Crie um produto seguindo o Schemas [Status: True = Ativo, False = Rascunho], *Inserir o ID da Categoria",
          OperationId = nameof(ProductPost),
          Tags = new[] { "Product" })]
    public static async Task<IResult> Action(ProductRequest productRequest, DataContext context)
    {
        var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == productRequest.CategoryId);
        var tagsStringBuilder = new StringBuilder();

        foreach (var tag in productRequest.Tags)
        {
            tagsStringBuilder.Append($"{tag},");
        }

        var product = new Product(
            productRequest.Title,
            productRequest.Description,
            productRequest.MidiaUrl,
            productRequest.Status,
            productRequest.Price,
            productRequest.PromotionalPrice,
            tagsStringBuilder.ToString().TrimEnd(','),
            category);

        if (!product.IsValid)
        {
            return Results.ValidationProblem(product.Notifications.ConvertToProblemDetails());
        }

        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();

        return Results.Created($"/products/{product.Id}", product.Id);
    }
}