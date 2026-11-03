
using G_ASP_NET_83_EFCore3.Entities;
using G_ASP_NET_83_EFCore3.Entities.Enums;
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



        builder.HasData(
            new Course
            {
                Id = 1,
                Title = "C# Fundamentals",
                Description = "Learn C# from scratch",
                Price = 500,
                Level = CourseLevel.Beginner,
                IsPublished = true,
                PublishedDate = new DateTime(2025, 1, 10),
                InstructorId = 1,
                CategoryId = 1
            },
            new Course
            {
                Id = 2,
                Title = "ASP.NET Core",
                Description = "Learn ASP.NET Core Web Development",
                Price = 800,
                Level = CourseLevel.Intermediate,
                IsPublished = true,
                PublishedDate = new DateTime(2025, 2, 15),
                InstructorId = 1,
                CategoryId = 4
            },
            new Course
            {
                Id = 3,
                Title = "Flutter Basics",
                Description = "Mobile Development with Flutter",
                Price = 600,
                Level = CourseLevel.Beginner,
                IsPublished = true,
                PublishedDate = new DateTime(2025, 3, 1),
                InstructorId = 2,
                CategoryId = 3
            },
            new Course
            {
                Id = 4,
                Title = "Advanced Flutter",
                Description = "Advanced Mobile Development",
                Price = 1000,
                Level = CourseLevel.Advanced,
                IsPublished = false,
                PublishedDate = null,
                InstructorId = 2,
                CategoryId = 3
            },
            new Course
            {
                Id = 5,
                Title = "SQL Fundamentals",
                Description = "Learn SQL and Database Basics",
                Price = 400,
                Level = CourseLevel.Beginner,
                IsPublished = true,
                PublishedDate = new DateTime(2025, 4, 10),
                InstructorId = 3,
                CategoryId = 5
            },
            new Course
            {
                Id = 6,
                Title = "Advanced Database",
                Description = "Advanced Database Concepts",
                Price = 900,
                Level = CourseLevel.Advanced,
                IsPublished = false,
                PublishedDate = null,
                InstructorId = 3,
                CategoryId = 5
            }
        );

    }
}
