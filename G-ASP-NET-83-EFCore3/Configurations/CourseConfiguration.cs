
using G_ASP_NET_83_EFCore3.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Title)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(c => c.Description)
               .HasMaxLength(1000);

        builder.Property(c => c.Price)
               .IsRequired()
               .HasPrecision(10, 2);

        builder.Property(c => c.Level)
               .IsRequired();

        builder.Property(c => c.IsPublished)
               .IsRequired();

        builder.Property(c => c.PublishedDate)
               .IsRequired(false);

        // Instructor - Course
        builder.HasOne(c => c.Instructor)
               .WithMany(i => i.Courses)
               .HasForeignKey(c => c.InstructorId)
               .IsRequired();

        // Category - Course
        builder.HasOne(c => c.Category)
               .WithMany(cat => cat.Courses)
               .HasForeignKey(c => c.CategoryId)
               .IsRequired();
    }
}
