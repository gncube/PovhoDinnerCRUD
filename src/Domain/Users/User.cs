using Domain.Users.ValueObjects;

namespace Domain.Users;

public class User
{
    public UserId Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; }
}

