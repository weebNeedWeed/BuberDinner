using Domain.Common.Models;
using Domain.Dinner.ValueObjects;
using Domain.Guest.ValueObjects;
using Domain.Host.ValueObjects;

namespace Domain.Guest.Entities;

public sealed class GuestRating : Entity<GuestRatingId>
{
    public float Rating { get; }
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private GuestRating(
        GuestRatingId guestRatingId,
        float rating,
        HostId hostId,
        DinnerId dinnerId,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(guestRatingId)
    {
        Rating = rating;
        HostId = hostId;
        DinnerId = dinnerId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static GuestRating Create(
        float rating,
        HostId hostId,
        DinnerId dinnerId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        return new(
            GuestRatingId.CreateUnique(),
            rating,
            hostId,
            dinnerId,
            createdDateTime,
            updatedDateTime);
    }
}