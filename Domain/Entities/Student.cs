using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Student
{
    public int pk_student_id { get; set; }

    public string name { get; set; } = null!;

    public string email { get; set; } = null!;

    public virtual ICollection<Enrollment> enrollments { get; set; } = new List<Enrollment>();
}
