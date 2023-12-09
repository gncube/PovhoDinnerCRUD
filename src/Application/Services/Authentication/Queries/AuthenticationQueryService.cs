using Application.Common.Interfaces;
using Application.Services.Authentication.Common;
using Domain.Common.Errors;
using Domain.Users;
using ErrorOr;

namespace Application.Services.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user)
            return Errors.Authentication.InvalidCredentials;

        if (user.Password != password)
            return Errors.Authentication.InvalidCredentials;

        string token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}