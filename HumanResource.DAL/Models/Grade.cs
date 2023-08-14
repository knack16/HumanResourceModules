using System;
using System.Collections.Generic;

namespace HumanResource.DAL.Models;

public partial class Grade
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<GradesHistory> GradesHistories { get; set; } = new List<GradesHistory>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
