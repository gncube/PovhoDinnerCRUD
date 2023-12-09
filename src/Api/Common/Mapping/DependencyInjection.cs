using Mapster;
using MapsterMapper;

namespace Api.Common.Mapping;

public static class DependencyInjection
{
    public static IServiceCollection AddCommonMapping(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(typeof(DependencyInjection).Assembly);
        //config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);

        // https://github.com/MapsterMapper/Mapster/blob/master/src/Mapster.DependencyInjection/ServiceCollectionExtensions.cs
        services.AddTransient<IMapper, Mapper>();
        return services;
    }
}
