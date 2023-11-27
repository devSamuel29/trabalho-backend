using System.Text.Json.Serialization;

namespace Models;

public class PlaylistModel
{
    public int Id { get; set; }

    public int PlaylistNum { get; set; }

    public int UserId { get; set; }

    [JsonIgnore]    
    public UserModel? User { get; set; } = null!;
}
