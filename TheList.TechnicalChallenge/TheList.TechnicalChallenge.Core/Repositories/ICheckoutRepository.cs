using System.Threading.Tasks;
using TheList.TechnicalChallenge.Core.Models;

namespace TheList.TechnicalChallenge.Core.Repositories
{
    public interface ICheckoutRepository
    {
        Task<Checkout> GetCheckoutAsync(int id);
        Task UpdateCheckoutAsync(Checkout checkout);
    }
}
