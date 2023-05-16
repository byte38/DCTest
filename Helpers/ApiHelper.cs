using DCTest.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace DCTest.Helpers {
    public class ApiHelper {
        private readonly HttpClient _httpClient;

        private readonly JsonSerializerOptions _options = new () { PropertyNameCaseInsensitive = true };

        public ApiHelper (IHttpClientFactory httpClientFactory) {
            _httpClient = httpClientFactory.CreateClient ("CoinCapClient");
        }

        public async Task<List<Data>> GetData (int count = 100) {
            var request = new HttpRequestMessage (HttpMethod.Get, $"assets?limit={count}");

            var response = _httpClient.Send (request);
            response.EnsureSuccessStatusCode ();

            var assets = await JsonSerializer.DeserializeAsync<Payload> (await response.Content.ReadAsStreamAsync (), _options);

            return assets.Data;
        }
    }
}
