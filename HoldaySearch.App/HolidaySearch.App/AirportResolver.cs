using HolidaySearch.App.Contracts;

namespace HolidaySearch.App;

public class AirportResolver : IAirportResolver
{
    private readonly Dictionary<string, string[]> _cityToAirports = new()
    {
        { "London", ["LGW", "LTN"] },
    };

    public IEnumerable<string> GetAirportsForLocation(string location)
    {
        return _cityToAirports.TryGetValue(location, out var airports) 
            ? airports 
            : Enumerable.Empty<string>();
    }
}