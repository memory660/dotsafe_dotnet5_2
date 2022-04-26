using Com.Core.Dotsafe.Infrastructure.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Com.Core.Dotsafe.UI.ExtensionsMethods
{
    public static class OptionsMethods
    {
        public static void AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<SecurityOption>(configuration.GetSection("Jwt"));
        }
    }
}
