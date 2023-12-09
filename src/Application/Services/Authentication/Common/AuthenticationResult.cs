using Domain.Users;

namespace Application.Services.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);
