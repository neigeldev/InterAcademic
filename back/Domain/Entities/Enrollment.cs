using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Enrollment
{
    public int fk_student_id { get; set; }

    public int fk_course_id { get; set; }

    public DateTime enrolled_at { get; set; }

    public virtual Course fk_course { get; set; } = null!;

    public virtual Student fk_student { get; set; } = null!;
}
