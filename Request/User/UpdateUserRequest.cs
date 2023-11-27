namespace Request.User;

public class UpdateUserRequest
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;
    
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}