using CountriesWebApp.Model;
using System.Text.Json;

namespace CountriesWebApp
{
    public class CountriesService : ICountriesService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _url;

        public CountriesService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _url = configuration["CountriesApi:Url"];
        }

        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _url);
            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<Country>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                })!;
            }
            return Enumerable.Empty<Country>();
        }
    }
}
