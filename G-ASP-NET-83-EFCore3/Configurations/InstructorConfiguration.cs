
using G_ASP_NET_83_EFCore3.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.FullName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(i => i.Email)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(i => i.Bio)
               .HasMaxLength(500);

        builder.Property(i => i.JoinedDate)
               .IsRequired();



        builder.HasData(
            new Instructor
            {
                Id = 1,
                FullName = "Ahmed Mohamed",
                Email = "ahmed@example.com",
                Bio = "C# and ASP.NET Instructor",
                JoinedDate = new DateTime(2024, 1, 10)
            },
            new Instructor
            {
                Id = 2,
                FullName = "Omar Ali",
                Email = "omar@example.com",
                Bio = "Mobile Development Instructor",
                JoinedDate = new DateTime(2024, 3, 15)
            },
            new Instructor
            {
                Id = 3,
                FullName = "Sara Hassan",
                Email = "sara@example.com",
                Bio = "Database Instructor",
                JoinedDate = new DateTime(2024, 5, 20)
            }
        );

    }
}
