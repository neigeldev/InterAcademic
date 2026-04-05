using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> entity)
    {
        entity.HasKey(e => e.pk_teacher_id).HasName("PRIMARY");

        entity.ToTable("teacher");

        entity.HasIndex(e => e.email, "uq_teacher_email")
            .IsUnique();

        entity.Property(e => e.email)
            .HasMaxLength(150);

        entity.Property(e => e.name)
            .HasMaxLength(150);
    }
}