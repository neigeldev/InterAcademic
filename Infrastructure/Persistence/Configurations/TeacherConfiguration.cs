using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Persistence.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("teacher");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).HasColumnName("pk_teacher_id");
        builder.Property(t => t.Name).HasColumnName("name").IsRequired();
        builder.Property(t => t.Email).HasColumnName("email").IsRequired();
        builder.HasIndex(t => t.Email).IsUnique();
    }
}