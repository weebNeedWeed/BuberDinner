using Domain.Bill.ValueObjects;
using Domain.Common.Models;
using Domain.Common.ValueObjects;
using Domain.Dinner.ValueObjects;
using Domain.Guest.ValueObjects;
using Domain.Host.ValueObjects;

namespace Domain.Bill;

public sealed class Bill : AggregateRoot<BillId>
{
    public Price Price { get; }
    public DinnerId DinnerId { get; }
    public GuestId GuestId { get; }
    public HostId HostId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Bill(
        BillId billId,
        Price price,
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(billId)
    {
        Price = price;
        DinnerId = dinnerId;
        GuestId = guestId;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Bill Create(
        Price price,
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        return new(
            BillId.CreateUnique(),
            price,
            dinnerId,
            guestId,
            hostId,
            createdDateTime,
            updatedDateTime);
    }
}