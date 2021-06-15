using System.Threading.Tasks;
using TheList.TechnicalChallenge.Core.Models;

namespace TheList.TechnicalChallenge.Application.UseCase
{
    public interface IGetCheckoutUseCase
    {
        Task<Checkout> GetCheckoutAsync(int id);
        Task<Checkout> ApplyCheckoutPromoCodeAsync(int id, string promoCode);
    }
}
