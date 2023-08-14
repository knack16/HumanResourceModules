using System;
using System.Collections.Generic;

namespace HumanResource.DAL.Models;

public partial class ReimbursementType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<ReimbursementRequest> ReimbursementRequests { get; set; } = new List<ReimbursementRequest>();
}
