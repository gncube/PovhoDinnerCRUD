using Application.Services.Authentication.Commands.Register;
using Application.Services.Authentication.Common;
using Application.Services.Authentication.Queries.Login;
using Contracts.Authentication;
using Mapster;

namespace Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, TRequest>();
        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}
