using CountriesWebApp.Model;

namespace CountriesWebApp
{
    public interface ICountriesService
    {
        Task<IEnumerable<Country>> GetAllCountriesAsync();
    }
}
