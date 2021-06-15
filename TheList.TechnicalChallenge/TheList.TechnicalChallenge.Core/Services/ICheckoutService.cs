using System.Threading.Tasks;
using TheList.TechnicalChallenge.Core.Models;

namespace TheList.TechnicalChallenge.Core.Services
{
    public interface ICheckoutService
    {
        public Task<Checkout> GetCheckoutByIdAsync(int id);
        Task UpdateCheckout(Checkout checkout);
    }
}
