using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Application.Services.Authentication.Common;
using Domain.Common.Errors;
using Domain.Users;
using Domain.Users.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Services.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (_userRepository.GetUserByEmail(command.Email) is not null)
            return Errors.User.DuplicateEmail;

        var user = new User
        {
            Id = new UserId(Guid.NewGuid()),
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };

        _userRepository.Add(user);

        string token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}