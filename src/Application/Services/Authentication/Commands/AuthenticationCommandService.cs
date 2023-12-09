using Application.Common.Interfaces;
using Application.Services.Authentication.Common;
using Domain.Users;
using Domain.Users.ValueObjects;

namespace Application.Services.Authentication.Commands;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Check if email is already registered
        if (_userRepository.GetUserByEmail(email) != null)
            throw new Exception("Email already registered.");

        var user = new User
        {
            Id = new UserId(Guid.NewGuid()),
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        // Create Jwt Token
        string token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}