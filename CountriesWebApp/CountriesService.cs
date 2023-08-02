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

        public async Task<IEnumerable<Country>> GetCountriesAsync(string country, int? population, string countrySort, int? numberOfRecords)
        {
            var countries = await _apiClient.GetAllCountriesAsync();
            
            countries = FilterCountries(countries, country);
            countries = FilterByPopulation(countries, population);
            countries = SortCountries(countries, countrySort);
            countries = GetFirstNRecords(countries, numberOfRecords);

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

        private static IEnumerable<Country> FilterByPopulation(IEnumerable<Country> countries, int? millions)
        {
            if (!millions.HasValue)
            {
                return countries;
            }

            return countries.Where(c => c.Population < millions.Value * 1000000);
        }

        private static IEnumerable<Country> SortCountries(IEnumerable<Country> countries, string sortDirection)
        {
            if (string.IsNullOrEmpty(sortDirection))
            {
                return countries;
            }

            if (sortDirection.ToLower() == "ascend")
            {
                return countries.OrderBy(country => country.Name.Common);
            }
            else if (sortDirection.ToLower() == "descend")
            {
                return countries.OrderByDescending(country => country.Name.Common);
            }

            return countries;
        }

        private static IEnumerable<Country> GetFirstNRecords(IEnumerable<Country> countries, int? numberOfRecords)
        {
            if (!numberOfRecords.HasValue || numberOfRecords.Value <= 0)
            {
                return countries;
            }

            return countries.Take(numberOfRecords.Value);
        }
    }
}
