using Domain.Common.Models;
using Domain.Menu.ValueObjects;

namespace Domain.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();

    public string Name { get; private set; }
    public string Description { get; private set; }
    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private MenuSection()
    {

    }

    private MenuSection(
        MenuSectionId menuSectionId,
        string name,
        string description,
        List<MenuItem> items)
        : base(menuSectionId)
    {
        Name = name;
        Description = description;
        _items.AddRange(items);
    }

    public static MenuSection Create(
        string name,
        string description,
        List<MenuItem> items)
    {
        return new MenuSection(
            MenuSectionId.CreateUnique(),
            name,
            description,
            items);
    }
}