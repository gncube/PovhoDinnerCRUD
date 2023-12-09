using Application.Common.Interfaces;
using Domain.Users;
using Domain.Users.ValueObjects;

namespace Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
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