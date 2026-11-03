
using G_ASP_NET_83_EFCore3.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        // Composite Primary Key
        builder.HasKey(e => new { e.StudentId, e.CourseId });

        builder.Property(e => e.EnrollmentDate)
               .IsRequired();

        builder.Property(e => e.Progress)
               .IsRequired();

        builder.Property(e => e.Status)
               .IsRequired();

        builder.Property(e => e.FinalGrade)
               .HasPrecision(5, 2)
               .IsRequired(false);

        // Student - Enrollment
        builder.HasOne(e => e.Student)
               .WithMany(s => s.Enrollments)
               .HasForeignKey(e => e.StudentId)
               .IsRequired();

        // Course - Enrollment
        builder.HasOne(e => e.Course)
               .WithMany(c => c.Enrollments)
               .HasForeignKey(e => e.CourseId)
               .IsRequired();
    }
}
