using Domain.Common.Models;
using Domain.Menu.ValueObjects;

using ErrorOr;

namespace Domain.Menu.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    private MenuItem(MenuItemId menuItemId, string name, string description)
        : base(menuItemId)
    {
        Name = name;
        Description = description;
    }

    private MenuItem()
    {

    }

    public static MenuItem Create(string name, string description)
    {
        return new MenuItem(MenuItemId.CreateUnique(), name, description);
    }

}