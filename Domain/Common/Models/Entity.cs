namespace Domain.Common.Models;

public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : notnull
{
    public TId Id { get; protected set; }

    protected Entity()
    {

    }

    protected Entity(TId id)
    {
        Id = id;
    }

    public override bool Equals(object? other)
    {
        if (other is null)
        {
            return false;
        }

        if (other.GetType() != this.GetType())
        {
            return false;
        }

        if (other is not Entity<TId> entity)
        {
            return false;
        }

        return Id.Equals(entity.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other);
    }

    public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
    {
        return left is not null
               && right is not null
               && left.Equals(right);
    }

    public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
    {
        return !(left == right);
    }
}