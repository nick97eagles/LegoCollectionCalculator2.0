using System.Data.Common;
using System.Text;

namespace LegoCollectionCalculator2._0.Server.Helpers.OAuth;

    internal class OAuthRequest
    {
        private readonly string _consumerKey;
        private readonly string _consumerSecret;
        private readonly string _token;
        private readonly string _tokenSecret;
        private readonly string _requestUrl;
        private readonly string _method;

        public OAuthRequest(
            string consumerKey,
            string consumerSecret,
            string token,
            string tokenSecret,
            string requestUrl,
            string method)
        {
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
            _token = token;
            _tokenSecret = tokenSecret;
            _requestUrl = requestUrl;
            _method = method;
        }
        private string BuildAuthHeader(
            string signature,
            string timestamp,
            string nonce)
        {
            var builder = new StringBuilder();
            builder.Append("OAuth ");
            builder.Append($"oauth_consumer_key=\"{_consumerKey}\",");
            builder.Append($"oauth_nonce=\"{nonce}\",");
            builder.Append($"oauth_signature=\"{signature}\",");
            builder.Append("oauth_signature_method=\"HMAC-SHA1\",");
            builder.Append($"oauth_timestamp=\"{timestamp}\",");
            builder.Append($"oauth_token=\"{_token}\",");
            builder.Append("oauth_version=\"1.0\"");
            return builder.ToString();
        }

        private void AddAuthParamters(List<WebParameter> parameter, string timestamp, string nonce)
        {
            var authParameters = new List<WebParameter>
            {
                new WebParameter("oauth_consumer_key", _consumerKey),
                new WebParameter("oauth_token", _token),
                new WebParameter("oauth_signature_method", "HMAC-SHA1"),
                new WebParameter("oauth_timestamp", timestamp),
                new WebParameter("oauth_nonce", nonce),
                new WebParameter("oauth_version", "1.0")
            };

            parameter.AddRange(authParameters);
        }

        private string GetSignature(string timestamp, string nonce, List<WebParameter>? queryParameters = null)
        {
            var parameters = queryParameters ?? new List<WebParameter>();
            AddAuthParamters(parameters, timestamp, nonce);
            var signatureBase = OAuthUtilities.ConcatenateRequestElements(_method.ToUpperInvariant(), _requestUrl, parameters);
            var signature = OAuthUtilities.GetSignature(signatureBase, _consumerSecret, _tokenSecret);
            return signature;
        }

        public string GetAuthorizationHeader(List<WebParameter>? queryParameters = null)
        {
            var timestamp = OAuthUtilities.GetTimestamp();
            var nonce = OAuthUtilities.GetNonce();
            var signature = GetSignature(timestamp, nonce, queryParameters);
            var header = BuildAuthHeader(signature, timestamp, nonce);
            return header;
        }
    }