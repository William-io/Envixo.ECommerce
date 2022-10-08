using Flunt.Notifications;

namespace Envixo.Ecommerce.App.Domain;

public class Entity : Notifiable<Notification>
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
}