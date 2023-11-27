using Request;

namespace Repositories.Playlist.Abstractions;

public interface IPlaylistRepository
{
    Task CreatePlaylistAsync(PlaylistRequest request);

    Task DeletePlaylistUserAsync(PlaylistRequest request);
}
