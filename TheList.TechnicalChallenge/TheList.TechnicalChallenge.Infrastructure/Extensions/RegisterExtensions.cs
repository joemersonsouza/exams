using Microsoft.Extensions.DependencyInjection;
using TheList.TechnicalChallenge.Core.Repositories;
using TheList.TechnicalChallenge.Infrastructure.Persistence;

namespace TheList.TechnicalChallenge.Infrastructure.Extensions
{
    public static class RegisterExtensions
    {
        public static void AddAllRepositories(this IServiceCollection services)
        {
            services.AddScoped<BackupCheckoutRepository>();
            services.AddScoped<CheckoutRepository>();
            services.AddScoped<ICheckoutRepositoryFactory>((serviceprovider) => new CheckoutRepositoryFactory(serviceprovider));
            services.AddScoped<IPromotionCodeRepository, PromotionCodeRepository>();
        }
    }
}
