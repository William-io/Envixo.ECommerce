namespace Envixo.Ecommerce.App.Endpoints.Categories;

public class CategoryPost
{
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    [SwaggerOperation(
          Summary = "Criar uma categoria",
          Description = "Crie uma categoria com um nome",
          OperationId = nameof(CategoryPost),
          Tags = new[] { "Category" })]
    public static async Task<IResult> Action(CategoryRequest categoryRequest, DataContext context)
    {
        var category = new Category(categoryRequest.Name, categoryRequest.Active);

        if (!category.IsValid)
        {
            return Results.ValidationProblem(category.Notifications.ConvertToProblemDetails());
        }

        await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();

        return Results.Created($"/categories/{category.Id}", category.Id);
    }
}