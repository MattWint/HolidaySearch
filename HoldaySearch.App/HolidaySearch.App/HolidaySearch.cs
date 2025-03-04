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

        Results = _flightsSearchResult.Select(x => new HolidaySearchResponse
        {
            Flight = x,
            Hotel = _hotelSearchResult.First()
        }).ToList();
    }

    private void FindHotels(HolidaySearchRequest request)
    {
        var hotels = Hotels.Data.AsEnumerable();

        hotels = hotels.Where(x => x.ArrivalDate == request.DepartureDate);

        hotels = hotels.Where(x => x.Nights == request.Duration);

        _hotelSearchResult = hotels.OrderBy(x => x.PricePerNight);
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

        flights = flights.Where(x => x.To == request.ArrivingAt);
        
        _flightsSearchResult = flights.OrderBy(x => x.Price);
    }

    public List<HolidaySearchResponse> Results { get; }
}