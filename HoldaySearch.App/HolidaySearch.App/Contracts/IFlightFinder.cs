using HolidaySearch.App.Models;

namespace HolidaySearch.App.Contracts;

public interface IFlightFinder
{
    IEnumerable<Flight> FindFlights(HolidaySearchRequest request, IEnumerable<Flight> flights);
}