namespace Contracts.Authentication;
public record AuthenticationResponseLegacy(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token);
