using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StanzaApi.Iso20022Parser
{
    public class Iso20022ParserClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _baseUrl;
        public string ToolUrl { get; } = "https://stanzaapi.com/tools/iso20022-parser";

        public Iso20022ParserClient(string apiKey = null, string baseUrl = null, HttpClient httpClient = null)
        {
            _apiKey = apiKey ?? Environment.GetEnvironmentVariable("STANZA_API_KEY") ?? Environment.GetEnvironmentVariable("API_KEY") ?? "";
            _baseUrl = (baseUrl ?? "https://api.stanzaapi.com/iso20022-parser").TrimEnd('/');
            _httpClient = httpClient ?? new HttpClient { Timeout = TimeSpan.FromSeconds(15) };
        }

        private async Task<string> SendRequestAsync(string endpoint, HttpMethod method, string jsonBody = null)
        {
            var url = $"{_baseUrl}/{endpoint.TrimStart('/')}";
            var request = new HttpRequestMessage(method, url);
            request.Headers.Add("Accept", "application/json");

            if (!string.IsNullOrEmpty(_apiKey))
            {
                request.Headers.Add("x-api-key", _apiKey);
                request.Headers.Add("Authorization", $"Bearer {_apiKey}");
            }

            if (jsonBody != null)
            {
                request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            }

            var response = await _httpClient.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }

        public Task<string> GetHealthAsync()
        {
            return SendRequestAsync("/health", HttpMethod.Get);
        }

        public Task<string> ValidateAsync(string jsonPayload)
        {
            return SendRequestAsync("/api/v1/validate", HttpMethod.Post, jsonPayload);
        }

        public Task<string> ParseAsync(string jsonPayload)
        {
            return SendRequestAsync("/api/v1/parse", HttpMethod.Post, jsonPayload);
        }
    }
}
