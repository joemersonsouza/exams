using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheList.TechnicalChallenge.Core.Entities;
using TheList.TechnicalChallenge.Core.Repositories;

namespace TheList.TechnicalChallenge.Infrastructure.Persistence
{
    public class PromotionCodeRepository : IPromotionCodeRepository
    {
        private static readonly IEnumerable<PromotionCode> PromotionCodes = new[]
        {
            new PromotionCode { Id = 1, Code = "10OFF", Discount = 0.1M }
        };

        public Task<PromotionCode> GetPromotionCodeAsync(string code)
        {
            return Task.FromResult(PromotionCodes.FirstOrDefault(checkout => checkout.Code == code));
        }
    }
}
