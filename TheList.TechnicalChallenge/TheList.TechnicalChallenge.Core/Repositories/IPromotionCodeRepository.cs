using System.Threading.Tasks;
using TheList.TechnicalChallenge.Core.Entities;

namespace TheList.TechnicalChallenge.Core.Repositories
{
    public interface IPromotionCodeRepository
    {
        Task<PromotionCode> GetPromotionCodeAsync(string code);
    }
}
