using Application.Services.Authentication.Commands;
using Application.Services.Authentication.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();

        return services;
    }
}
