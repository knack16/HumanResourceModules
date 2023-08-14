using System;
using System.Collections.Generic;

namespace HumanResource.DAL.Models;

public partial class Reservation
{
    public int Id { get; set; }

    public int ReservationDoneByEmployeeId { get; set; }

    public int TravelRequestId { get; set; }

    public int ReservationTypeId { get; set; }

    public DateTime CreatedOn { get; set; }

    public string ReservationDoneWithEntity { get; set; } = null!;

    public DateTime ReservationDate { get; set; }

    public int Amount { get; set; }

    public string ConfirmationId { get; set; } = null!;

    public string? Remarks { get; set; }

    public virtual ICollection<ReservationDoc> ReservationDocs { get; set; } = new List<ReservationDoc>();

    public virtual ReservationType ReservationType { get; set; } = null!;

    public virtual TravelRequest TravelRequest { get; set; } = null!;
}
