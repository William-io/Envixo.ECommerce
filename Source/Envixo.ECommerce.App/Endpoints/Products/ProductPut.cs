namespace Envixo.Ecommerce.App.Endpoints.Products;

public class ProductPut
{
    public static string Template => "/products/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    [SwaggerOperation(
          Summary = "Atualizar um produto",
          Description = "Precisa-se inserir o ID",
          OperationId = nameof(ProductPut),
          Tags = new[] { "Product" })]
    public static async Task<IResult> Action([FromRoute] Guid id, ProductRequest productRequest, DataContext context)
    {
        var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == productRequest.CategoryId);
        var product = context.Products.Where(c => c.Id == id).FirstOrDefault();

        if (product == null)
            return Results.NotFound();

        var tagsStringBuilder = new StringBuilder();

        foreach (var tag in productRequest.Tags)
        {
            tagsStringBuilder.Append($"{tag},");
        }

        product.EditInfo(productRequest.Title,
            productRequest.Description,
            productRequest.MidiaUrl,
            productRequest.Status,
            productRequest.Price,
            productRequest.PromotionalPrice,
            tagsStringBuilder.ToString().TrimEnd(','),
            category);

        if (!product.IsValid)
            return Results.ValidationProblem(product.Notifications.ConvertToProblemDetails());

        await context.SaveChangesAsync();

        return Results.Ok();
    }
}
