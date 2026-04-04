using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Persistence.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("course");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("pk_course_id");
        builder.Property(c => c.TeacherId).HasColumnName("fk_teacher_id");
        builder.Property(c => c.CourseName).HasColumnName("course_name").IsRequired();
        builder.Property(c => c.Credits).HasColumnName("credits");
        builder.HasOne(c => c.Teacher)
               .WithMany(t => t.Courses)
               .HasForeignKey(c => c.TeacherId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}