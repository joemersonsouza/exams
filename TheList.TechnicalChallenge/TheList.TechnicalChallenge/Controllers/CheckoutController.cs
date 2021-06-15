using Microsoft.AspNetCore.Mvc;
using TheList.TechnicalChallenge.Application.UseCase;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TheList.TechnicalChallenge.Controllers
{
    [ApiController]
    [Route("v1/the-list")]
    public class CheckoutController : ControllerBase
    {
        private readonly IGetCheckoutUseCase getCheckoutUseCase;

        public CheckoutController(IGetCheckoutUseCase getCheckoutUseCase)
        {
            this.getCheckoutUseCase = getCheckoutUseCase;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var checkout = await getCheckoutUseCase.GetCheckoutAsync(id);
            return new OkObjectResult(checkout);
        }

        [HttpPut("{id}/{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ApplyCheckoutPromoCodeAsync([FromRoute] int id, [FromRoute] string promoCode)
        {
            var checkout = await getCheckoutUseCase.ApplyCheckoutPromoCodeAsync(id, promoCode);
            return new OkObjectResult(checkout);
        }
    }
}
