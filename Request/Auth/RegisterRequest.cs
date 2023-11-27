namespace Request.Auth;

public class RegisterRequest
{
    public string FirstName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool Terms { get; set; }

    public DateTime RegisterDate { get; set; }
}
