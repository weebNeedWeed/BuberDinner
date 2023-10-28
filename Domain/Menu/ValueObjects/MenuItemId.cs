using Domain.Common.Models;

namespace Domain.Menu.ValueObjects;

public sealed class MenuItemId : ValueObject
{
    public Guid Value { get; private set; }

    private MenuItemId(Guid value)
    {
        Value = value;
    }

    private MenuItemId()
    {
    }

    public static MenuItemId CreateUnique()
    {
        return new MenuItemId(Guid.NewGuid());
    }

    public static MenuItemId Create(Guid value)
    {
        return new MenuItemId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}