namespace Envixo.Ecommerce.App.Endpoints.Products;

public record ProductResponse(Guid Id, string Title, string Description, string MidiaUrl, bool Status, decimal Price, string Tags, string Type);