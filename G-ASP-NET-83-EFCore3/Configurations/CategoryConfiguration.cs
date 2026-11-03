using G_ASP_NET_83_EFCore3.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(c => c.Description)
               .HasMaxLength(500);

        // Self Relationship
        builder.HasOne(c => c.ParentCategory)
               .WithMany(c => c.SubCategories)
               .HasForeignKey(c => c.ParentCategoryId)
               .OnDelete(DeleteBehavior.Restrict);

        // Category - Courses
        builder.HasMany(c => c.Courses)
               .WithOne(c => c.Category)
               .HasForeignKey(c => c.CategoryId)
               .IsRequired();





        builder.HasData(
            new Category
            {
                Id = 1,
                Name = "Programming",
                Description = "Programming Courses",
                ParentCategoryId = null
            },
            new Category
            {
                Id = 2,
                Name = "Web Development",
                Description = "Web Development Courses",
                ParentCategoryId = 1
            },
            new Category
            {
                Id = 3,
                Name = "Mobile Development",
                Description = "Mobile Development Courses",
                ParentCategoryId = 1
            },
            new Category
            {
                Id = 4,
                Name = "ASP.NET",
                Description = "ASP.NET Courses",
                ParentCategoryId = 2
            },
            new Category
            {
                Id = 5,
                Name = "Database",
                Description = "Database Courses",
                ParentCategoryId = null
            }
        );

    }
}