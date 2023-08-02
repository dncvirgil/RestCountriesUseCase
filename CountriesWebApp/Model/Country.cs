public class Country
{
    public Name Name { get; set; }
    public string[] Tld { get; set; }
    public string Cca2 { get; set; }
    public string Ccn3 { get; set; }
    public string Cca3 { get; set; }
    public string Cioc { get; set; }
    public bool Independent { get; set; }
    public string Status { get; set; }
    public bool UnMember { get; set; }
    public Dictionary<string, Currency> Currencies { get; set; }
    public Idd Idd { get; set; }
    public string[] Capital { get; set; }
    public string[] AltSpellings { get; set; }
    public string Region { get; set; }
    public string Subregion { get; set; }
    public Dictionary<string, string> Languages { get; set; }
    public Dictionary<string, Translation> Translations { get; set; }
    public double[] Latlng { get; set; }
    public bool Landlocked { get; set; }
    public string[] Borders { get; set; }
    public double Area { get; set; }
    public Dictionary<string, Demonym> Demonyms { get; set; }
    public string Flag { get; set; }
    public Dictionary<string, string> Maps { get; set; }
    public int Population { get; set; }
    public Gini Gini { get; set; }
    public string Fifa { get; set; }
    public Car Car { get; set; }
    public string[] Timezones { get; set; }
    public string[] Continents { get; set; }
    public Flags Flags { get; set; }
    public CoatOfArms CoatOfArms { get; set; }
    public string StartOfWeek { get; set; }
    public CapitalInfo CapitalInfo { get; set; }
    public PostalCode PostalCode { get; set; }
}

public class Name
{
    public string Common { get; set; }
    public string Official { get; set; }
    public Dictionary<string, NativeName> NativeName { get; set; }
}

public class NativeName
{
    public string Official { get; set; }
    public string Common { get; set; }
}

public class Currency
{
    public string Name { get; set; }
    public string Symbol { get; set; }
}

public class Idd
{
    public string Root { get; set; }
    public string[] Suffixes { get; set; }
}

public class Translation
{
    public string Official { get; set; }
    public string Common { get; set; }
}

public class Demonym
{
    public string F { get; set; }
    public string M { get; set; }
}

public class Gini
{
    public double? Year { get; set; }
}

public class Car
{
    public string[] Signs { get; set; }
    public string Side { get; set; }
}

public class Flags
{
    public string Png { get; set; }
    public string Svg { get; set; }
    public string Alt { get; set; }
}

public class CoatOfArms
{
    public string Png { get; set; }
    public string Svg { get; set; }
}

public class CapitalInfo
{
    public double[] Latlng { get; set; }
}

public class PostalCode
{
    public string Format { get; set; }
    public string Regex { get; set; }
}
