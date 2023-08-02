using CountriesWebApp.Model;

namespace CountriesWebApp
{
    public static class CountryFilter
    {
        public static IEnumerable<Country> FilterCountries(this IEnumerable<Country> countries, string country)
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

        public static IEnumerable<Country> FilterByPopulation(this IEnumerable<Country> countries, int? millions)
        {
            if (!millions.HasValue)
            {
                return countries;
            }

            return countries.Where(c => c.Population < millions.Value * 1000000);
        }

        public static IEnumerable<Country> SortCountries(this IEnumerable<Country> countries, string sortDirection)
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

        public static IEnumerable<Country> GetFirstNRecords(this IEnumerable<Country> countries, int? numberOfRecords)
        {
            if (!numberOfRecords.HasValue || numberOfRecords.Value <= 0)
            {
                return countries;
            }

            return countries.Take(numberOfRecords.Value);
        }
    }
}
