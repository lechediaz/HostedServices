using Core.Services;
using Core.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Core
{
    public static class MyLogServiceExtensions
    {
        public static IServiceCollection AddMyLogService(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<EscribirArchivoSettings>(
                config.GetSection(nameof(EscribirArchivoSettings)));

            services.AddSingleton(provider => 
                provider.GetRequiredService<IOptions<EscribirArchivoSettings>>().Value);

            services.AddHostedService<MyLogService>();

            return services;
        }
    }
}
