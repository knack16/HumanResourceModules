using System;
using System.Collections.Generic;

namespace HumanResource.DAL.Models;

public partial class ReimbursementRequest
{
    public int Id { get; set; }

    public int TravelRequestId { get; set; }

    public int RequestRaisedByEmployeeId { get; set; }

    public DateTime RequestDate { get; set; }

    public int ReimbursementTypeId { get; set; }

    public string InvoiceNo { get; set; } = null!;

    public DateTime InvoiceDate { get; set; }

    public int InvoiceAmount { get; set; }

    public string DocumentUrl { get; set; } = null!;

    public DateTime? RequestProcessedOn { get; set; }

    public int? RequestProcessedByEmployeeId { get; set; }

    public string Status { get; set; } = null!;

    public string? Remarks { get; set; }

    public virtual ReimbursementType ReimbursementType { get; set; } = null!;

    public virtual User? RequestProcessedByEmployee { get; set; }

    public virtual User RequestRaisedByEmployee { get; set; } = null!;

    public virtual TravelRequest TravelRequest { get; set; } = null!;
}
