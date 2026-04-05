using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> entity)
    {
        entity.HasKey(e => new { e.fk_student_id, e.fk_course_id })
            .HasName("PRIMARY")
            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

        entity.ToTable("enrollment");

        entity.HasIndex(e => e.fk_course_id, "fk_enrollment_course");

        entity.Property(e => e.enrolled_at)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("datetime");

        entity.HasOne(d => d.fk_course)
            .WithMany(p => p.enrollments)
            .HasForeignKey(d => d.fk_course_id)
            .HasConstraintName("fk_enrollment_course");

        entity.HasOne(d => d.fk_student)
            .WithMany(p => p.enrollments)
            .HasForeignKey(d => d.fk_student_id)
            .HasConstraintName("fk_enrollment_student");
    }
}