using LegoCollectionCalculator2._0.Server.API.Extension;

namespace LegoCollectionCalculator2._0.Server.Services
{
    public class BrickLinkService : IBrickLinkService
    {
        private static readonly Uri baseUri = new("https://api.bricklink.com/api/store/v1/");
        
        public BrickLinkService()
        {
        }

        public async Task<string> GetSet(string itemId, CancellationToken cancellationToken = default)
        {
            var url = new Uri(baseUri, $"items/set/{itemId}").ToString();
            var _httpClient = new HttpClient();
            var response = await _httpClient.ExecuteRequestAsync(url, HttpMethod.Get, cancellationToken);

            return response;
        }

        public async Task<string> GetSetPriceGuide(string itemId, string n_or_u, CancellationToken cancellactionToken = default)
        {
            var setCondition = n_or_u[0];
            var url = new Uri(baseUri, $"items/set/{itemId}/price?new_or_used={setCondition}").ToString();
            var _httpClient = new HttpClient();
            var response = await _httpClient.ExecuteRequestAsync(url, HttpMethod.Get, cancellactionToken);

            return response;
        }
    }
}
