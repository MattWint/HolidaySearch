using HolidaySearch.App.Data;

namespace HolidaySearch.App;

public class HolidaySearch
{
    private readonly Dictionary<string, string[]> _cityToAirports = new()
    {
        { "London", ["LGW", "LTN"] },
    };
    
    private IEnumerable<Flight> _flightsSearchResult;
    private IEnumerable<Hotel> _hotelSearchResult;
    
    public HolidaySearch(HolidaySearchRequest request)
    {
        FindFlights(request);
        FindHotels(request);
        
        Results = _hotelSearchResult
            .SelectMany(_ => _flightsSearchResult, (hotel, flight) => new HolidaySearchResponse
            {
                Hotel = hotel,
                Flight = flight
            })
            .OrderBy(x => x.Flight.Price + x.Hotel.PricePerNight) // Duration is constant for a given search so we don't need to factor it into the price
            .ToList();
    }

    private void FindHotels(HolidaySearchRequest request)
    {
        var hotels = Hotels.Data.AsEnumerable();

        hotels = hotels.Where(x => x.ArrivalDate == request.DepartureDate);

        _hotelSearchResult = hotels.Where(x => x.Nights == request.Duration);
    }

    private void FindFlights(HolidaySearchRequest request)
    {
        var flights = Flights.Data.AsEnumerable();

        flights = flights.Where(x => x.DepartureDate == request.DepartureDate);

        if (!string.IsNullOrWhiteSpace(request.DepartingFrom))
        {
            if (_cityToAirports.TryGetValue(request.DepartingFrom, out var airports))
            {
                flights = flights.Where(x => airports.Contains(x.From));
            }
            else
            {
                flights = flights.Where(x => x.From == request.DepartingFrom);
            }
        }

        _flightsSearchResult = flights.Where(x => x.To == request.ArrivingAt);
    }

    public List<HolidaySearchResponse> Results { get; }
}