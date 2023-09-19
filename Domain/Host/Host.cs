using Domain.Common.Models;
using Domain.Dinner.ValueObjects;
using Domain.Host.ValueObjects;
using Domain.Menu.ValueObjects;
using Domain.User.ValueObjects;

namespace Domain.Host;

public sealed class Host : AggregateRoot<HostId>
{
    private readonly List<MenuId> _menuIds = new();
    private readonly List<DinnerId> _dinnerIds = new();

    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public float AverageRating { get; }
    public UserId UserId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

    private Host(
        HostId id,
        string firstName,
        string lastName,
        string profileImage,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Host Create(
        string firstName,
        string lastName,
        string profileImage,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        return new Host(
            HostId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            userId,
            createdDateTime,
            updatedDateTime);
    }
}
