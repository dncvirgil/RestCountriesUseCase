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
        int? page = null)
    {
        var countries = await _countriesService.GetAllCountriesAsync();

        // Filter or modify the countries based on the provided parameters.
        return Ok(countries);
    }
}
