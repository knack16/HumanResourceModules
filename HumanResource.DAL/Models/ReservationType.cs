using System;
using System.Collections.Generic;

namespace HumanResource.DAL.Models;

public partial class ReservationType
{
    public int TypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
