using Domain.Common.Models;

namespace Domain.Host.ValueObjects;

public sealed class HostId : ValueObject
{
    public Guid Value { get; private set; }

    private HostId(Guid value)
    {
        Value = value;
    }

    private HostId()
    {
    }

    public static HostId CreateUnique()
    {
        return new HostId(Guid.NewGuid());
    }

    public static HostId Create(string value)
    {
        return new HostId(new Guid(value));
    }

    public static HostId Create(Guid value)
    {
        return new HostId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}