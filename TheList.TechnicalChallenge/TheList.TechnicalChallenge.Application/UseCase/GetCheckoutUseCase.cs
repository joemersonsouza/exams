using System.Threading.Tasks;
using TheList.TechnicalChallenge.Core.Models;
using TheList.TechnicalChallenge.Core.Repositories;
using TheList.TechnicalChallenge.Core.Services;

namespace TheList.TechnicalChallenge.Application.UseCase
{
    public class GetCheckoutUseCase : IGetCheckoutUseCase
    {
        private readonly ICheckoutService checkoutService;
        private readonly IPromotionCodeRepository promotionRepository;

        public GetCheckoutUseCase(ICheckoutService checkoutService, IPromotionCodeRepository promotionRepository)
        {
            this.checkoutService = checkoutService;
            this.promotionRepository = promotionRepository;
        }

        public async Task<Checkout> GetCheckoutAsync(int id)
        {
            return await checkoutService.GetCheckoutByIdAsync(id);
        }

        public async Task<Checkout> ApplyCheckoutPromoCodeAsync(int id, string code)
        {
            if(string.IsNullOrWhiteSpace(code))
            {
                return null;
            }
            var promoCode = await promotionRepository.GetPromotionCodeAsync(code);
            if(promoCode == null)
            {
                return null;
            }

            var checkout = await checkoutService.GetCheckoutByIdAsync(id);
            if (checkout == null)
            {
                return null;
            }

            checkout.TotalPrice -= (checkout.TotalPrice * promoCode.Discount);

            return checkout;
        }
    }
}
