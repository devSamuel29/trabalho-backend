using Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Mapper;

public sealed class PlaylistMapper : IEntityTypeConfiguration<PlaylistModel>
{
    public void Configure(EntityTypeBuilder<PlaylistModel> builder)
    {
        builder.ToTable("Playlists");

        builder.HasKey(p => p.Id);
        builder
            .Property(p => p.Id)
            .HasColumnType("INTEGER")
            .HasColumnName("Id")
            .UseIdentityColumn();

        builder
            .Property(p => p.PlaylistNum)
            .HasColumnType("INTEGER")
            .HasColumnName("PlaylistNum")
            .IsRequired();

        builder.HasOne(p => p.User).WithMany(p => p.Playlists).HasForeignKey(p => p.UserId);
    }
}
