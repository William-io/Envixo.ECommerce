namespace Envixo.Ecommerce.App.Endpoints.Products;

public class ProductDelete
{
    public static string Template => "/products/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    [SwaggerOperation(
           Summary = "Deletar um produto",
           Description = "Precisa-se inserir o ID",
           OperationId = nameof(ProductDelete),
           Tags = new[] { "Product" })]
    public static async Task<IResult> Action([FromRoute] Guid id, DataContext context)
    {
        var product = context.Products.Where(c => c.Id == id).FirstOrDefault();

        context.Remove(product);
        await context.SaveChangesAsync();

        return Results.Ok();
    }
}
