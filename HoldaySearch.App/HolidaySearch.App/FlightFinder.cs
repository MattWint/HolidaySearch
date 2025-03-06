using HolidaySearch.App.Contracts;
using HolidaySearch.App.Models;

namespace HolidaySearch.App;

public class FlightFinder(IAirportResolver airportResolver) : IFlightFinder
{
    public IEnumerable<Flight> FindFlights(HolidaySearchRequest request, IEnumerable<Flight> flights)
    {
        var filteredFlights = flights.Where(x => x.DepartureDate == request.DepartureDate);

        if (!string.IsNullOrWhiteSpace(request.DepartingFrom))
        {
            var airports = airportResolver.GetAirportsForLocation(request.DepartingFrom).ToList();
            
            if (airports.Count > 0)
            {
                filteredFlights = filteredFlights.Where(x => airports.Contains(x.From));
            }
            else
            {
                filteredFlights = filteredFlights.Where(x => x.From == request.DepartingFrom);
            }
        }

        return filteredFlights.Where(x => x.To == request.ArrivingAt);
    }
}