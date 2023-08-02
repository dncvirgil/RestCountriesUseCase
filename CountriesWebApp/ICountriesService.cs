using CountriesWebApp.Model;

namespace CountriesWebApp
{
    public interface ICountriesService
    {
        Task<IEnumerable<Country>> GetCountriesAsync(string country, int? population, string countrySort, int? numberOfRecords);
    }
}
