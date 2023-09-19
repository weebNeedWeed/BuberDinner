using Domain.Bill.ValueObjects;
using Domain.Common.Models;
using Domain.Dinner.Enums;
using Domain.Dinner.ValueObjects;
using Domain.Guest.ValueObjects;

namespace Domain.Dinner.Entities;

public sealed class Reservation : Entity<ReservationId>
{
    public int GuestCount { get; }
    public ReservationStatus ReservationStatus { get; }
    public DateTime? ArrivalDateTime { get; }
    public GuestId GuestId { get; }
    public BillId BillId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Reservation(
        ReservationId reservationId,
        int guestCount,
        ReservationStatus reservationStatus,
        DateTime? arrivalDateTime,
        GuestId guestId,
        BillId billId,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(reservationId)
    {
        GuestCount = guestCount;
        ReservationStatus = reservationStatus;
        ArrivalDateTime = arrivalDateTime;
        GuestId = guestId;
        BillId = billId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Reservation Create(
        int guestCount,
        ReservationStatus reservationStatus,
        DateTime? arrivalDateTime,
        GuestId guestId,
        BillId billId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        return new(
            ReservationId.CreateUnique(),
            guestCount,
            reservationStatus,
            arrivalDateTime,
            guestId,
            billId,
            createdDateTime,
            updatedDateTime);
    }
}