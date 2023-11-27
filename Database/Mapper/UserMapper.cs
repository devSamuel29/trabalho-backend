using Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Mapper;

public sealed class UserMapper : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(p => p.Id);
        builder
            .Property(p => p.Id)
            .HasColumnType("INTEGER")
            .HasColumnName("Id")
            .UseIdentityColumn();

        builder
            .Property(p => p.FirstName)
            .HasColumnType("VARCHAR(20)")
            .HasColumnName("FirstName")
            .IsRequired();

        builder.HasIndex(p => p.Email).IsUnique();
        builder
            .Property(p => p.Email)
            .HasColumnType("VARCHAR(50)")
            .HasColumnName("Email")
            .IsRequired();

        builder
            .Property(p => p.Password)
            .HasColumnType("VARCHAR(16)")
            .HasColumnName("Password")
            .IsRequired();

        builder.Property(p => p.Terms).HasColumnType("BIT").HasColumnName("Terms").IsRequired();

        builder
            .Property(p => p.RegisterDate)
            .HasColumnType("DATE")
            .HasColumnName("RegisterDate")
            .IsRequired();
    }
}
