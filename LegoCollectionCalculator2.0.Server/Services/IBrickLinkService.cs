namespace LegoCollectionCalculator2._0.Server.Services
{
    public interface IBrickLinkService
    {
        Task<string> GetSet(string itemId, CancellationToken cancellationToken = default);
    }
}
