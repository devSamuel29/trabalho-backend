namespace Models;

public class UserModel
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool Terms { get; set; }

    public DateTime RegisterDate { get; set; }

    public IList<PlaylistModel>? Playlists { get; set; }
}
