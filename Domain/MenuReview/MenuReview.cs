using Domain.Common.Models;
using Domain.Dinner.ValueObjects;
using Domain.Guest.ValueObjects;
using Domain.Host.ValueObjects;
using Domain.Menu.ValueObjects;
using Domain.MenuReview.ValueObjects;

namespace Domain.MenuReview;

public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
    public float Rating { get; }
    public string Comment { get; }
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public GuestId GuestId { get; }
    public MenuId MenuId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private MenuReview(
        MenuReviewId menuReviewId,
        float rating,
        string comment,
        HostId hostId,
        DinnerId dinnerId,
        GuestId guestId,
        MenuId menuId,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(menuReviewId)
    {
        Rating = rating;
        Comment = comment;
        HostId = hostId;
        DinnerId = dinnerId;
        GuestId = guestId;
        MenuId = menuId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static MenuReview Create(
        float rating,
        string comment,
        HostId hostId,
        DinnerId dinnerId,
        GuestId guestId,
        MenuId menuId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        return new(
            MenuReviewId.CreateUnique(),
            rating,
            comment,
            hostId,
            dinnerId,
            guestId,
            menuId,
            createdDateTime,
            updatedDateTime);
    }
}