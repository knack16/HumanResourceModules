using System;
using System.Collections.Generic;

namespace HumanResource.DAL.Models;

public partial class Location
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TravelRequest> TravelRequests { get; set; } = new List<TravelRequest>();
}
