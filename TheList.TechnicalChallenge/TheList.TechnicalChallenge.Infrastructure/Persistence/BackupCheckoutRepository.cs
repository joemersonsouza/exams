using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheList.TechnicalChallenge.Core.Models;
using TheList.TechnicalChallenge.Core.Repositories;

namespace TheList.TechnicalChallenge.Infrastructure.Persistence
{
    public class BackupCheckoutRepository : ICheckoutRepository
    {
        private static readonly IEnumerable<Checkout> Checkouts = new[]
        {
            new Checkout { Id = 1, TotalPrice = 100 },
            new Checkout { Id = 2, TotalPrice = 200 },
            new Checkout { Id = 3, TotalPrice = 300 }
        };

        public Task<Checkout> GetCheckoutAsync(int id)
        {
            return Task.FromResult(Checkouts.FirstOrDefault(checkout => checkout.Id == id));
        }

        public Task UpdateCheckoutAsync(Checkout checkout)
        {
            return Task.CompletedTask;
        }
    }
}
