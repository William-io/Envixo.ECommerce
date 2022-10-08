using Flunt.Validations;

namespace Envixo.Ecommerce.App.Domain.Products;

public class Category : Entity
{
    // public Category(string name, bool active)
    // {
    //     Name = name;
    //     Active = true;

    //     Validate();
    // }

    public string Name { get; set; } = null!;
    public bool Active { get; set; } = true;

    private void Validate()
    {
        var contract = new Contract<Category>()
            .IsNotNullOrEmpty(Name, "Name")
            .IsGreaterOrEqualsThan(Name, 3, "Name");
        AddNotifications(contract);
    }
}