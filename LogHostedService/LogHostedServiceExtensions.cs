using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace LogHostedService
{
    public static class LogHostedServiceExtensions
    {
        /// <summary>
        /// Toma la sección LogHostedServiceSettings de la configuración y registra LogHostedService como un HostedService
        /// </summary>
        public static IServiceCollection AddLogHostedService(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<LogHostedServiceSettings>(
                config.GetSection(nameof(LogHostedServiceSettings)));

            services.AddSingleton(provider => 
                provider.GetRequiredService<IOptions<LogHostedServiceSettings>>().Value);

            services.AddHostedService<LogHostedService>();

            return services;
        }
    }
}
