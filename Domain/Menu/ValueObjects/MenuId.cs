using Domain.Common.Models;

namespace Domain.Menu.ValueObjects;

public sealed class MenuId : ValueObject
{
    public Guid Value { get; private set; }

    private MenuId()
    {

    }

    private MenuId(Guid value)
    {
        Value = value;
    }

    public static MenuId CreateUnique()
    {
        return new MenuId(Guid.NewGuid());
    }

    public static MenuId Create(Guid value)
    {
        return new MenuId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}