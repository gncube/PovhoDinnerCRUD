using Application.Services.Authentication.Common;

namespace Application.Services.Authentication.Commands;
public interface IAuthenticationCommandService
{
    AuthenticationResult Register(string firstName, string lastName, string email, string password);
}
