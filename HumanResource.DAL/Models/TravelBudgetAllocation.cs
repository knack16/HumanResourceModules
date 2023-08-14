using System;
using System.Collections.Generic;

namespace HumanResource.DAL.Models;

public partial class TravelBudgetAllocation
{
    public int Id { get; set; }

    public int TravelRequestId { get; set; }

    public int ApprovedBudget { get; set; }

    public string ApprovedModeOfTravel { get; set; } = null!;

    public string ApprovedHotelStarRating { get; set; } = null!;

    public virtual TravelRequest TravelRequest { get; set; } = null!;
}
