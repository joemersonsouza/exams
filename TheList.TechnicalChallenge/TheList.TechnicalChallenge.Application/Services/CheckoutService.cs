using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using TheList.TechnicalChallenge.Core.Models;
using TheList.TechnicalChallenge.Core.Repositories;
using TheList.TechnicalChallenge.Core.Services;

namespace TheList.TechnicalChallenge.Application.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly ICheckoutRepositoryFactory checkoutRepositoryFactory;
        private readonly IConfiguration configuration;

        public CheckoutService(ICheckoutRepositoryFactory checkoutRepositoryFactory, IConfiguration configuration)
        {
            this.checkoutRepositoryFactory = checkoutRepositoryFactory;
            this.configuration = configuration;
        }

        public async Task<Checkout> GetCheckoutByIdAsync(int id)
        {
            var storeType = configuration.GetSection("DataStoreType").Value;
            var repository = checkoutRepositoryFactory.Create(storeType);

            return await repository.GetCheckoutAsync(id);
        }

        public async Task UpdateCheckout(Checkout checkout)
        {
            var storeType = configuration.GetSection("DataStoreType").Value;
            var repository = checkoutRepositoryFactory.Create(storeType);
            await checkoutRepositoryFactory.Create(storeType).UpdateCheckoutAsync(checkout);
        }
    }
}
