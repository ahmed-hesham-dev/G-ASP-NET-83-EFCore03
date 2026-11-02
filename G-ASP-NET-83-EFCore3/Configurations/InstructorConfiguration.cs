
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
    }
}
