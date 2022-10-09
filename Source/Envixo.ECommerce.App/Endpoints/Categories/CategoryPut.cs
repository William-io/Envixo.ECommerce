namespace Envixo.Ecommerce.App.Endpoints.Categories;

public class CategoryPut
{
    public static string Template => "/categories/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    [SwaggerOperation(
          Summary = "Atualizar uma categoria",
          Description = "Precisa-se inserir o ID",
          OperationId = nameof(CategoryPut),
          Tags = new[] { "Category" })]
    public static async Task<IResult> Action([FromRoute] Guid id, CategoryRequest categoryRequest, DataContext context)
    {
        var category = context.Categories.Where(c => c.Id == id).FirstOrDefault();

        if (category == null)
            return Results.NotFound();

        category.EditInfo(categoryRequest.Name, categoryRequest.Active);

        if (!category.IsValid)
            return Results.ValidationProblem(category.Notifications.ConvertToProblemDetails());

        await context.SaveChangesAsync();

        return Results.Ok();
    }
}
