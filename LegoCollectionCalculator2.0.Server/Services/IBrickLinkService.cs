namespace LegoCollectionCalculator2._0.Server.Services
{
    public interface IBrickLinkService
    {
        Task<string> GetSet(string itemId, CancellationToken cancellationToken = default);

        Task<string> GetSetPriceGuide(string itemId, string N_or_u, CancellationToken cancellationToken = default);
    }
}
