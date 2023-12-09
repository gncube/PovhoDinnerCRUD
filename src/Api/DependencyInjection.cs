using Api.Common.Errors;
using Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
        services.AddCommonMapping();
        return services;
    }
}
