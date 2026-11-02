
using G_ASP_NET_83_EFCore3.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.FullName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(s => s.Email)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(s => s.DateOfBirth)
               .IsRequired();
    }
}
