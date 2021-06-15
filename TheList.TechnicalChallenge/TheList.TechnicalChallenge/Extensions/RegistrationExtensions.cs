using Microsoft.Extensions.DependencyInjection;
using TheList.TechnicalChallenge.Application.UseCase;

namespace TheList.TechnicalChallenge.Controllers
{
    public static class RegistrationExtensions
    {
        public static void AddAllApplications(this IServiceCollection services)
        {
            services.AddScoped<IGetCheckoutUseCase, GetCheckoutUseCase>();
        }
    }
}
