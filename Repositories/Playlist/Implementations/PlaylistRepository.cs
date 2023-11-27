using Database.Context;
using Repositories.Playlist.Abstractions;
using Models;
using Request;
using Microsoft.EntityFrameworkCore;

namespace DataSource.Playlist.Implementations;

public sealed class PlaylistRepository : IPlaylistRepository
{
    private readonly MyDbContext _context;

    public PlaylistRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task CreatePlaylistAsync(PlaylistRequest request)
    {
        await _context.Playlists.AddAsync(
            new PlaylistModel() { PlaylistNum = request.PlaylistNum, UserId = request.UserId }
        );
        await _context.SaveChangesAsync();
    }

    public async Task DeletePlaylistUserAsync(PlaylistRequest request)
    {
        var playlist = await _context.Playlists.FirstAsync(
            p => p.UserId == request.UserId && p.PlaylistNum == request.PlaylistNum
        );
        _context.Playlists.Remove(playlist);
        await _context.SaveChangesAsync();
    }
}
