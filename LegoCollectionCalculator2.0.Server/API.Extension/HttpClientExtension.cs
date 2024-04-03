using System.Net.Http.Headers;
using LegoCollectionCalculator2._0.Server.Helpers.OAuth;

namespace LegoCollectionCalculator2._0.Server.API.Extension
{
    internal static class HttpClientExtension
    {
        // TODO: put these in appsettings
        private const string consumerKey = "3979E2305BC24227BEA2560C29307B91";
        private const string consumerSecret = "3F66F57615F84B44A8551424074CAB74";
        private const string tokenValue = "0B94C43BC5124349ADCCA127527C3A13";
        private const string tokenSecret = "A45EFC44A17C4ADF899B444B8552D3B5";

        public static async Task<string> ExecuteRequestAsync(
            this HttpClient http, string url, HttpMethod method, CancellationToken cancellationToken)
        {
            GetAuthHeader(url, method.ToString(),
                out var authScheme, out var authParameter);

            using var message = new HttpRequestMessage(method, url);
            message.Headers.Authorization = new AuthenticationHeaderValue(authScheme, authParameter);
            message.Content = null;

            var response = await http.SendAsync(message, cancellationToken);
            var contentAsString = await response.Content.ReadAsStringAsync(cancellationToken);

            return contentAsString;
        }

        private static void GetAuthHeader(string url, string method,
            out string scheme, out string parameter)
        {
            var request = new OAuthRequest(
                consumerKey,
                consumerSecret,
                tokenValue,
                tokenSecret,
                url,
                method);

            var header = request.GetAuthorizationHeader();
            var schemeParameter = header.Split(' ');
            scheme = schemeParameter[0];
            parameter = schemeParameter[1];
        }
    }
}
