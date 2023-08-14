using System;
using System.Collections.Generic;

namespace HumanResource.DAL.Models;

public partial class TravelRequest
{
    public int RequestId { get; set; }

    public int RaisedByEmployeeId { get; set; }

    public int ToBeApprovedByHrid { get; set; }

    public DateTime RequestRaisedOn { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public string PurposeOfTravel { get; set; } = null!;

    public int LocationId { get; set; }

    public string RequestStatus { get; set; } = null!;

    public DateTime? RequestApprovedOn { get; set; }

    public string Priority { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;

    public virtual User RaisedByEmployee { get; set; } = null!;

    public virtual ICollection<ReimbursementRequest> ReimbursementRequests { get; set; } = new List<ReimbursementRequest>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual User ToBeApprovedByHr { get; set; } = null!;

    public virtual ICollection<TravelBudgetAllocation> TravelBudgetAllocations { get; set; } = new List<TravelBudgetAllocation>();
}
