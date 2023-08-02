using CountriesWebApp.Model;
using System.Linq;
using System.Text.Json;

namespace CountriesWebApp
{
    public class CountriesService : ICountriesService
    {
        private readonly IApiClient _apiClient;

        public CountriesService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync(string country, int? population, string countrySort, int? page)
        {
            var countries = await _apiClient.GetAllCountriesAsync();
            
            countries = FilterCountries(countries, country);
            return countries;
        }

        private IEnumerable<Country> FilterCountries(IEnumerable<Country> countries, string country)
        {
            if (string.IsNullOrEmpty(country))
            {
                return countries; // If search is empty or null, return all countries
            }

            // Perform the filtering using LINQ
            var filteredCountries = countries.Where(c =>
                c.Name.Common.Contains(country, StringComparison.OrdinalIgnoreCase)
            );

            return filteredCountries;
        }
    }
}
