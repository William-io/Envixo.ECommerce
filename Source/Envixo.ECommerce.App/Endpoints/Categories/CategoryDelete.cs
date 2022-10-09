namespace Envixo.Ecommerce.App.Endpoints.Categories;

public class CategoryDelete
{
    public static string Template => "/categories/{id:guid}";

    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };

    public static Delegate Handle => Action;

    public static async Task<IResult> Action([FromRoute] Guid id, DataContext context)
    {
        var category = context.Categories.Where(c => c.Id == id).FirstOrDefault();

        context.Remove(category);
        await context.SaveChangesAsync();

        return Results.Ok();
    }
}
