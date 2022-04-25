using Com.Core.Dotsafe.Domain;
using Com.Core.Dotsafe.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Com.Core.Dotsafe.UI.ExtensionsMethods
{
    public static class DIMethods
    {
        #region Public methods
        /// <summary>
        /// Prepare customs dependency injections
        /// </summary>
        /// <param name="services"></param>
        public static void AddInjections(this IServiceCollection services)
        {
            services.AddScoped<IContributionRepository, DefaultContributionRepository>();
        }
        #endregion
    }
}
