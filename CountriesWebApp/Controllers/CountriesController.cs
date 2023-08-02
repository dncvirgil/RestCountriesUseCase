using Microsoft.AspNetCore.Mvc;

namespace CountriesWebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    private readonly ICountriesService _countriesService;

    public CountriesController(ICountriesService countriesService)
    {
        _countriesService = countriesService;
    }

    [HttpGet()]
    public async Task<IActionResult> GetCountries(
        string country = null,
        int? population = null,
        string countrySort = null,
        int? numberOfRecords = null)
    {
        var countries = await _countriesService.GetCountriesAsync(country, population, countrySort, numberOfRecords);

        return Ok(countries);
    }
}
