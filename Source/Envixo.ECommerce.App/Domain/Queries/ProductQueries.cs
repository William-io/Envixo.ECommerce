using System.Linq.Expressions;

namespace Envixo.Ecommerce.App.Queries;

public class ProductQueries
{
    public static Expression<Func<Product, bool>> GetActiveProducts()
    {
        return x => x.Status;
    }

    public static Expression<Func<Product, bool>> GetInactiveProducts()
    {
        return x => x.Status == false;
    }
}