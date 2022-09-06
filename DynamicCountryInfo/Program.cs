using DynamicCountryInfo.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;

List<Country> contries = new();
List<string> List = new List<string>
        {
                "http://country.io/names.json",
                "http://country.io/phone.json",
                "http://country.io/iso3.json",
                "http://country.io/capital.json",
                "http://country.io/currency.json",
                "http://country.io/continent.json"
        };


HttpClient client = new();

Dictionary<string, string> Names = new Dictionary<string, string>();
Dictionary<string, string> Phone = new Dictionary<string, string>();
Dictionary<string, string> Iso3 = new Dictionary<string, string>();
Dictionary<string, string> Capital = new Dictionary<string, string>();
Dictionary<string, string> Currency = new Dictionary<string, string>();
Dictionary<string, string> Continent = new Dictionary<string, string>();

foreach (string url in List)
{
    var response = client.GetStringAsync(url).Result;
    var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);

    if (url == "http://country.io/names.json")
        Names = result;
    else if (url == "http://country.io/phone.json")
        Phone = result;
    else if (url == "http://country.io/iso3.json")
        Iso3 = result;
    else if (url == "http://country.io/capital.json")
        Capital = result;
    else if (url == "http://country.io/currency.json")
        Currency = result;
    else if (url == "http://country.io/continent.json")
        Continent = result;
}

Console.WriteLine($"Phone      ISO       Capital       Currency       ContinentId      Code      Name  ");
Console.WriteLine(new String('-', 100));

foreach (var item in Names)
{
    Country cntry = new Country(
         item.Key.Trim(),
         item.Value.Trim(),
         Phone[item.Key].Trim(),
         Iso3[item.Key].Trim(),
         Capital[item.Key].Trim(),
         Currency[item.Key].Trim(),
         Continent[item.Key].Trim()
    );
    contries.Add(cntry);
    Console.WriteLine($"{cntry.Phone}   {cntry.ISO}     {cntry.Capital}     {cntry.Currency}   {cntry.ContinentId}   {cntry.Code}  {cntry.Name}");
}
