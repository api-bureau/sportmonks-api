using ApiBureau.Sportmonks.Api.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ApiBureau.Sportmonks.Api.Extensions;

public static class ServiceExtension
{
    public static void AddSportmonks(this IServiceCollection services, IConfigurationRoot configuration)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        if (configuration == null) throw new ArgumentNullException(nameof(configuration));

        services.Configure<SportmonksSettings>(options => configuration.GetSection(nameof(SportmonksSettings)).Bind(options));
        services.AddHttpClient<ClientHelper>();
        //services.TryAddSingleton(Options.Create(configuration.GetSection(nameof(SportMonksSettings)).Get<SportMonksSettings>()));
        services.TryAddSingleton<SportMonksClient>();
    }
}
