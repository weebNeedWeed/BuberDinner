using Domain.Common.Models;

namespace Domain.Dinner.ValueObjects;

public sealed class DinnerId : ValueObject
{
    public Guid Value { get; }

    private DinnerId()
    {
    }

    private DinnerId(Guid value)
    {
        Value = value;
    }

    public static DinnerId CreateUnique()
    {
        return new DinnerId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
