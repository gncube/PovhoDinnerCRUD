using Domain.Users;

namespace Application.Services.Authentication;

public record AuthenticationResponse(
       User User,
       string Token);