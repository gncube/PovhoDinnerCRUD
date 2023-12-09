using Application.Services.Authentication.Common;
using ErrorOr;

namespace Application.Services.Authentication;
public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
}
