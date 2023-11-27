using Microsoft.AspNetCore.Mvc;
using Repositories.Playlist.Abstractions;
using Request;

namespace Controllers.Playlist;

[ApiController]
[Route("[controller]")]
public class PlaylistController : ControllerBase
{
    private readonly IPlaylistRepository _repository;

    public PlaylistController(IPlaylistRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("create-playlist")]
    public async Task<IActionResult> CreatePlaylist([FromBody] PlaylistRequest request)
    {
        try
        {
            await _repository.CreatePlaylistAsync(request);
            return NoContent();
        }
        catch (Exception e)
        {
            return StatusCode(500, $"SERVER ERROR: {e.Message}");
        }
    }

    [HttpDelete("create-playlist")]
    public async Task<IActionResult> DeletePlaylistUser([FromBody] PlaylistRequest request)
    {
        try
        {
            await _repository.DeletePlaylistUserAsync(request);
            return NoContent();
        }
        catch (Exception e)
        {
            return StatusCode(500, $"SERVER ERROR: {e.Message}");
        }
    }
}
