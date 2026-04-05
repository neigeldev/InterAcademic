using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> entity)
    {
        entity.HasKey(e => e.pk_student_id).HasName("PRIMARY");

        entity.ToTable("student");

        entity.HasIndex(e => e.email, "uq_student_email")
            .IsUnique();

        entity.Property(e => e.email)
            .HasMaxLength(150);

        entity.Property(e => e.name)
            .HasMaxLength(150);
    }
}