namespace HolidaySearch.App.Contracts;

public interface IAirportResolver
{
    IEnumerable<string> GetAirportsForLocation(string location);
}