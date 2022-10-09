namespace Envixo.Ecommerce.App.Domain.Repositories.Interfaces;

public interface IProductRepository
{
    IEnumerable<Product> Get(IEnumerable<Guid> ids);
}