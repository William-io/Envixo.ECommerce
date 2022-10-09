namespace Envixo.Ecommerce.App.Endpoints.Categories;

public class CategoryGetAll
{
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    [SwaggerOperation(
          Summary = "Obter lista de categorias",
          Description = "Obter lista",
          OperationId = nameof(CategoryGetAll),
          Tags = new[] { "Category" })]
    public static IResult Action(DataContext context)
    {
        var categories = context.Categories.ToList();

        var response = categories.Select(c => new CategoryResponse(c.Id, c.Name, c.Active));

        return Results.Ok(response);
    }
}