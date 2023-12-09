using Domain.Users;

namespace Application.Services.Authentication.Common;

public record AuthenticationResponse(
       User User,
       string Token);