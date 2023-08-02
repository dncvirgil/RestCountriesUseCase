using CountriesWebApp.Model;
using CountriesWebApp;
using Moq;

namespace CountryServiceTests
{
    public class CountriesServiceUnitTests
    {
        private readonly Mock<IApiClient> _apiClientMock;
        private readonly CountriesService _countriesService;

        public CountriesServiceUnitTests()
        {
            _apiClientMock = new Mock<IApiClient>();
            _countriesService = new CountriesService(_apiClientMock.Object);
        }

        [Fact]
        public async Task GetCountriesAsync_FiltersByCountry()
        {
            var countries = new List<Country>
            {
                new Country { Name = new Name { Common  = "USA" } },
                new Country { Name = new Name { Common  = "India" } },
                new Country { Name = new Name { Common  = "UK" } },
            };
            _apiClientMock.Setup(x => x.GetAllCountriesAsync()).ReturnsAsync(countries);

            var result = await _countriesService.GetCountriesAsync("India", null, null, null);

            Assert.Single(result);
            Assert.Equal("India", result.First().Name.Common);
        }

        [Fact]
        public async Task GetCountriesAsync_FiltersByPopulation()
        {
            var countries = new List<Country>
            {
                new Country { Name = new Name { Common  =  "USA"}, Population = 331_000_000 },
                new Country { Name = new Name { Common  = "India" }, Population = 1_380_000_000 },
                new Country { Name = new Name { Common  = "UK" }, Population = 67_000_000 },
            };
            _apiClientMock.Setup(x => x.GetAllCountriesAsync()).ReturnsAsync(countries);

            var result = await _countriesService.GetCountriesAsync(null, 400, null, null);

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetCountriesAsync_SortsByCountryName()
        {
            var countries = new List<Country>
            {
                new Country { Name = new Name { Common  ="Anglia" } },
                new Country { Name = new Name { Common  ="Bulgaria" } },
                new Country { Name = new Name { Common  ="Croatia" } },
            };
            _apiClientMock.Setup(x => x.GetAllCountriesAsync()).ReturnsAsync(countries);

            var result = await _countriesService.GetCountriesAsync(null, null, "descend", null);
            Assert.Equal(result.Last().Name.Common, countries.First().Name.Common);
        }

        [Fact]
        public async Task GetCountriesAsync_PaginatesResults()
        {
            var countries = Enumerable.Range(1, 100).Select(i => new Country { Name = new Name { Common = $"Country{i}" } }).ToList();
            _apiClientMock.Setup(x => x.GetAllCountriesAsync()).ReturnsAsync(countries);

            var result = await _countriesService.GetCountriesAsync(null, null, null, 10);

            Assert.Equal(10, result.Count());
        }
    }
}