using Flunt.Validations;

namespace Envixo.Ecommerce.App.Domain.Products;

public class Category : Entity
{
    public Category(string name, bool active)
    {
        Name = name;
        Active = active;

        Validate();
    }

    public string Name { get; private set; } = null!;
    public bool Active { get; private set; } = true;

    private void Validate()
    {
        var contract = new Contract<Category>()
            .IsNotNullOrEmpty(Name, "Name", "Nome da categoria é obrigatório.")
            .IsGreaterOrEqualsThan(Name, 3, "Name", "O nome precisa ser maior que 3 caracteres");
        AddNotifications(contract);
    }

    public void EditInfo(string name, bool active)
    {
        Active = active;
        Name = name;
        Validate();
    }
}