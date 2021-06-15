using Microsoft.Extensions.DependencyInjection;
using System;
using TheList.TechnicalChallenge.Core.Repositories;

namespace TheList.TechnicalChallenge.Infrastructure.Persistence
{
    public class CheckoutRepositoryFactory : ICheckoutRepositoryFactory
    {
        private readonly IServiceProvider serviceProvider;

        public CheckoutRepositoryFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ICheckoutRepository Create(string storeType)
        {
            bool isBackup = storeType.ToLower().Equals("backup");
            if (isBackup)
            {
                return serviceProvider.GetRequiredService<BackupCheckoutRepository>();
            }

            return serviceProvider.GetRequiredService<CheckoutRepository>();
        }
    }
}
