using CountriesWebApp.Model;

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

            return countries.FilterCountries(country)
                            .FilterByPopulation(population)
                            .SortCountries(countrySort)
                            .GetFirstNRecords(numberOfRecords);
        }
    }
}
