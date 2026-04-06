using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Teacher
{
    public int pk_teacher_id { get; set; }

    public string name { get; set; } = null!;

    public string email { get; set; } = null!;

    public virtual ICollection<Course> courses { get; set; } = new List<Course>();
}
