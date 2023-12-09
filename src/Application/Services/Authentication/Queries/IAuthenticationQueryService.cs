using Application.Services.Authentication.Common;

namespace Application.Services.Authentication;
public interface IAuthenticationQueryService
{
    AuthenticationResult Login(string email, string password);
}
