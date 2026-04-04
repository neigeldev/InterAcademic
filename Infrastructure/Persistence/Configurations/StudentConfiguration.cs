using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Persistence.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("student");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnName("pk_student_id");
        builder.Property(s => s.Name).HasColumnName("name").IsRequired();
        builder.Property(s => s.Email).HasColumnName("email").IsRequired();
        builder.HasIndex(s => s.Email).IsUnique();
    }
}