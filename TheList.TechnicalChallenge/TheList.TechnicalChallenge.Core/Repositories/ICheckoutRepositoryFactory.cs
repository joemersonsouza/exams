namespace TheList.TechnicalChallenge.Core.Repositories
{
    public interface ICheckoutRepositoryFactory
    {
        ICheckoutRepository Create(string storeType);
    }
}
