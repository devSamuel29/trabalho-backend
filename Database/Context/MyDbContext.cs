using Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Database.Context;

public sealed class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions options)
        : base(options) { }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);
    }

    public DbSet<UserModel> Users { get; set; } = null!;

    public DbSet<PlaylistModel> Playlists { get; set; } = null!;
}
