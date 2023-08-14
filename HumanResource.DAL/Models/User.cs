using System;
using System.Collections.Generic;

namespace HumanResource.DAL.Models;

public partial class User
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string Role { get; set; } = null!;

    public int CurrentGradeId { get; set; }

    public virtual Grade CurrentGrade { get; set; } = null!;

    public virtual ICollection<GradesHistory> GradesHistories { get; set; } = new List<GradesHistory>();

    public virtual ICollection<ReimbursementRequest> ReimbursementRequestRequestProcessedByEmployees { get; set; } = new List<ReimbursementRequest>();

    public virtual ICollection<ReimbursementRequest> ReimbursementRequestRequestRaisedByEmployees { get; set; } = new List<ReimbursementRequest>();

    public virtual ICollection<TravelRequest> TravelRequestRaisedByEmployees { get; set; } = new List<TravelRequest>();

    public virtual ICollection<TravelRequest> TravelRequestToBeApprovedByHrs { get; set; } = new List<TravelRequest>();
}
