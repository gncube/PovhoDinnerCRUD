using Application.Services.Authentication;
using Application.Services.Authentication.Commands;
using Application.Services.Authentication.Common;
using Application.Services.Authentication.Queries;
using Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ILogger<AuthenticationController> _logger;
    private readonly IAuthenticationCommandService _authenticationCommandService;
    private readonly IAuthenticationQueryService _authenticationQueryService;

    public AuthenticationController(
        ILogger<AuthenticationController> logger,
        IAuthenticationCommandService authenticationCommandService,
        IAuthenticationQueryService authenticationQueryService)
    {
        _logger = logger;
        _authenticationCommandService = authenticationCommandService;
        _authenticationQueryService = authenticationQueryService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationCommandService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }


    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        ErrorOr<AuthenticationResult> authResult = _authenticationQueryService.Login(request.Email, request.Password);

        if (authResult.IsError && authResult.FirstError == Domain.Common.Errors.Errors.Authentication.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
        }

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }


    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
            authResult.User,
            authResult.Token);
    }
}
