namespace Envixo.Ecommerce.App.Endpoints.Products;

public class ProductShowCase
{
    public static string Template => "/products/showcase";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(DataContext context, int page = 1, int row = 10, string orderBy = "title")
    {
        if (row > 10)
            return Results.Problem(title: "Row with max 10", statusCode: 400);

        var queryBase = context.Products.AsNoTracking().Include(p => p.Category)
            .Where(p => p.Status && p.Category.Active);

        if (orderBy == "title")
            queryBase = queryBase.OrderBy(p => p.Title);
        else if (orderBy == "price")
            queryBase = queryBase.OrderBy(p => p.Price);
        else
            return Results.Problem(title: "Order only by price or title", statusCode: 400);

        var queryFilter = queryBase.Skip((page - 1) * row).Take(row);

        var products = queryFilter.ToList();

        var results = products.Select(p => new ProductResponse(p.Id, p.Title, p.Description, p.MidiaUrl, p.Status, p.Price, p.Tags, p.Category.Name));
        return Results.Ok(results);
    }
}