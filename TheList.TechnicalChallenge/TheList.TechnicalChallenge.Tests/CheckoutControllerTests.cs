using Microsoft.AspNetCore.Mvc;
using Moq;
using TheList.TechnicalChallenge.Application.UseCase;
using TheList.TechnicalChallenge.Controllers;
using TheList.TechnicalChallenge.Core.Models;
using Xunit;

namespace TheList.TechnicalChallenge.Tests
{
    public class CheckoutControllerTests
    {
        private readonly CheckoutController controller;
        private readonly Mock<IGetCheckoutUseCase> getCheckoutUseCase;

        public CheckoutControllerTests()
        {
            getCheckoutUseCase = new Mock<IGetCheckoutUseCase>();
            controller = new CheckoutController(getCheckoutUseCase.Object);
        }

        [Fact]
        public void Get_Checkout_Should_Return_Successful()
        {
            var model = new Checkout()
            {
                Id = 1,
                TotalPrice = 12
            };

            getCheckoutUseCase.Setup(x => x.GetCheckoutAsync(It.IsAny<int>())).ReturnsAsync(model);

            var response = controller.GetAsync(1).Result;

            Assert.NotNull(response);
            Assert.Equal(model, (Checkout)((OkObjectResult)response).Value);
            getCheckoutUseCase.Verify(x => x.GetCheckoutAsync(It.IsAny<int>()), times: Times.Exactly(1));
        }

        [Fact]
        public void Get_Checkout_Should_Return_Null()
        {
            var response = controller.GetAsync(-1).Result;

            Assert.NotNull(response);
            Assert.Null(((OkObjectResult)response).Value);
            getCheckoutUseCase.Verify(x => x.GetCheckoutAsync(It.IsAny<int>()), times: Times.Exactly(1));
        }
    }
}
