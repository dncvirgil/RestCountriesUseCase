using CountriesWebApp.Model;

namespace CountriesWebApp
{
    public interface IApiClient
    {
        Task<IEnumerable<Country>> GetAllCountriesAsync();
    }
}
