using Domain.Common.Models;

namespace Domain.Menu.ValueObjects;

public sealed class MenuSectionId : ValueObject
{
    public Guid Value { get; private set; }

    private MenuSectionId()
    {
    }

    private MenuSectionId(Guid value)
    {
        Value = value;
    }

    public static MenuSectionId CreateUnique()
    {
        return new MenuSectionId(Guid.NewGuid());
    }

    public static MenuSectionId Create(Guid value)
    {
        return new MenuSectionId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}