namespace Envixo.Ecommerce.App.Endpoints.Products;

public record ProductRequest(string Title, string Description, string MidiaUrl, bool Status, decimal Price, IEnumerable<string> Tags, Guid CategoryId);
