using Application.Common.Interfaces;
using Application.Services.Authentication.Common;

namespace Application.Services.Authentication;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string email, string password)
    {
        // Validate password
        var user = _userRepository.GetUserByEmail(email);
        if (user == null)
            throw new Exception("Invalid email or password.");

        if (user.Password != password)
            throw new Exception("Invalid email or password.");

        // Create Jwt Token
        string token = _jwtTokenGenerator.GenerateToken(user);


        return new AuthenticationResult(
                user,
                token);
    }
}