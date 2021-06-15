using Moq;
using TheList.TechnicalChallenge.Application.UseCase;
using TheList.TechnicalChallenge.Core.Entities;
using TheList.TechnicalChallenge.Core.Models;
using TheList.TechnicalChallenge.Core.Repositories;
using TheList.TechnicalChallenge.Core.Services;
using Xunit;

namespace TheList.TechnicalChallenge.Tests
{
    public class GetCheckoutUseCaseTests
    {
        private readonly IGetCheckoutUseCase useCase;
        private readonly Mock<IPromotionCodeRepository> promotionRepository;
        private readonly Mock<ICheckoutService> checkoutService;
        public GetCheckoutUseCaseTests()
        {
            checkoutService = new Mock<ICheckoutService>();
            promotionRepository = new Mock<IPromotionCodeRepository>();
            useCase = new GetCheckoutUseCase(checkoutService.Object, promotionRepository.Object);
        }

        private Checkout GetCheckoutMock()
        {
            var model = new Checkout()
            {
                Id = 1,
                TotalPrice = 100
            };

            checkoutService.Setup(x => x.GetCheckoutByIdAsync(It.IsAny<int>())).ReturnsAsync(model);
            return model;
        }

        [Fact]
        public void Get_Checkout_Should_Return_Successful()
        {
            Checkout model = GetCheckoutMock();

            var response = useCase.GetCheckoutAsync(1).Result;

            Assert.NotNull(response);
            Assert.Equal(response, model);
            checkoutService.Verify(x => x.GetCheckoutByIdAsync(It.IsAny<int>()), times: Times.Once);
        }

        [Fact]
        public void Get_Checkout_Should_Return_Null()
        {
            var response = useCase.GetCheckoutAsync(1).Result;

            Assert.Null(response);
            checkoutService.Verify(x => x.GetCheckoutByIdAsync(It.IsAny<int>()), times: Times.Once);
        }

        [Fact]
        public void Apply_PromoCode_Existent_Checkout_Should_Return_Successful()
        {
            Checkout model = GetCheckoutMock();
            var promo = new PromotionCode() { Id = 1, Code = "CODE10OFF", Discount = 0.1M };
            promotionRepository.Setup(x => x.GetPromotionCodeAsync(It.IsAny<string>())).ReturnsAsync(promo);

            var response = useCase.ApplyCheckoutPromoCodeAsync(1, promo.Code).Result;

            Assert.NotNull(response);
            Assert.Equal(90, response.TotalPrice);
        }
    }
}
