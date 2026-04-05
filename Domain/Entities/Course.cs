using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Course
{
    public int pk_course_id { get; set; }

    public int fk_teacher_id { get; set; }

    public string course_name { get; set; } = null!;

    public int credits { get; set; }

    public virtual ICollection<Enrollment> enrollments { get; set; } = new List<Enrollment>();

    public virtual Teacher fk_teacher { get; set; } = null!;
}
