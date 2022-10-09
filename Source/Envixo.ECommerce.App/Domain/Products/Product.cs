using Flunt.Validations;

namespace Envixo.Ecommerce.App.Domain.Products;

public class Product : Entity
{
    public Product() { }
    public Product(string title, string description, string midiaUrl, bool status, decimal price, decimal promotionalPrice, string tags, Category category)
    {
        Title = title;
        Description = description;
        MidiaUrl = midiaUrl;
        Status = status;
        Price = price;
        PromotionalPrice = promotionalPrice;
        Tags = tags;
        Category = category;
        Validate();
    }

    public string Title { get; private set; } = null!;
    public string Description { get; set; } = null!;
    public string MidiaUrl { get; set; }
    public bool Status { get; set; } = true; //1 = Ativo, 0 = Rascunho 
    public decimal Price { get; set; }
    public decimal PromotionalPrice { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public string Tags { get; set; } = null!;

    private void Validate()
    {
        var contract = new Contract<Product>()
            .IsNotNullOrEmpty(Title, "Title")
            .IsGreaterOrEqualsThan(Title, 3, "Title")
            .IsNotNull(Category, "Category", "Category not found")
            .IsNotNullOrEmpty(Description, "Description")
            .IsGreaterOrEqualsThan(Description, 3, "Description")
            .IsGreaterOrEqualsThan(Price, 1, "Price");
        AddNotifications(contract);
    }

    public void EditInfo(string title, string description, string midiaUrl, bool status, decimal price, decimal promotionalPrice, string tags, Category category)
    {
        Title = title;
        Description = description;
        MidiaUrl = midiaUrl;
        Status = status;
        Price = price;
        PromotionalPrice = promotionalPrice;
        Tags = tags;
        Category = category;

        Validate();
    }
}

