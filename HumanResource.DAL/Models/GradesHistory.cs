using System;
using System.Collections.Generic;

namespace HumanResource.DAL.Models;

public partial class GradesHistory
{
    public int Id { get; set; }

    public DateTime AssignedOn { get; set; }

    public int EmployeeId { get; set; }

    public int GradeId { get; set; }

    public virtual User Employee { get; set; } = null!;

    public virtual Grade Grade { get; set; } = null!;
}
