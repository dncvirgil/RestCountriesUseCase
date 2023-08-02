using CountriesWebApp.Model;
using System.Diagnostics.Metrics;
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
            countries = FilterByPopulation(countries, population);

            return countries;
        }

        private static IEnumerable<Country> FilterCountries(IEnumerable<Country> countries, string country)
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

        public static IEnumerable<Country> FilterByPopulation(IEnumerable<Country> countries, int? millions)
        {
            if (!millions.HasValue)
            {
                return countries;
            }

            return countries.Where(c => c.Population < millions.Value * 1000000);
        }
    }
}
