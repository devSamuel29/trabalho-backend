using Models;

namespace Response;

public class UserResponse
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool Terms { get; set; }

    public DateTime RegisterDate { get; set; }

    public IList<int>? Playlists { get; set; }
}
