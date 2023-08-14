using System;
using System.Collections.Generic;

namespace HumanResource.DAL.Models;

public partial class ReservationDoc
{
    public int Id { get; set; }

    public int ReservationId { get; set; }

    public string DocumentUrl { get; set; } = null!;

    public virtual Reservation Reservation { get; set; } = null!;
}
