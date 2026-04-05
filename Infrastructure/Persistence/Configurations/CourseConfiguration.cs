using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> entity)
    {
        entity.HasKey(e => e.pk_course_id).HasName("PRIMARY");

        entity.ToTable("course");

        entity.HasIndex(e => e.fk_teacher_id, "fk_course_teacher");

        entity.Property(e => e.course_name)
            .HasMaxLength(200);

        entity.HasOne(d => d.fk_teacher)
            .WithMany(p => p.courses)
            .HasForeignKey(d => d.fk_teacher_id)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_course_teacher");
    }
}