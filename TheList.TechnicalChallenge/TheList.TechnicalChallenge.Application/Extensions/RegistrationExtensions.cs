using Microsoft.Extensions.DependencyInjection;
using TheList.TechnicalChallenge.Application.Services;
using TheList.TechnicalChallenge.Core.Services;

namespace TheList.TechnicalChallenge.Application
{
    public static class RegistrationExtensions
    {
        public static void AddAllServices(this IServiceCollection services)
        {
            services.AddScoped<ICheckoutService, CheckoutService>();
        }
    }
}
