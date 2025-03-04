using HolidaySearch.App.Data;

namespace HolidaySearch.App;

public class HolidaySearch
{
    private readonly Dictionary<string, string[]> _cityToAirports = new()
    {
        { "London", ["LGW", "LTN"] },
    };
    
    public HolidaySearch(string flightsDataPath, string hotelDataPath, HolidaySearchRequest request)
    {
        var flights = Flights.Data;

        flights = flights.Where(x => x.DepartureDate == request.DepartureDate).ToList();

        if (!string.IsNullOrWhiteSpace(request.DepartingFrom))
        {
            if (_cityToAirports.TryGetValue(request.DepartingFrom, out var airports))
            {
                flights = flights.Where(x => airports.Contains(x.From)).ToList();
            }
            else
            {
                flights = flights.Where(x => x.From == request.DepartingFrom).ToList();
            }
        }

        flights = flights.Where(x => x.To == request.ArrivingAt).ToList();
        
        var hotels = Hotels.Data;

        hotels = hotels.Where(x => x.ArrivalDate == request.DepartureDate).ToList();

        hotels = hotels.Where(x => x.Nights == request.Duration).ToList();

        flights = flights.OrderBy(x => x.Price).ToList();

        hotels = hotels.OrderBy(x => x.PricePerNight).ToList();


        Results = flights.Select(x => new HolidaySearchResponse
        {
            Flight = x,
            Hotel = hotels.First()
        }).ToList();
    }

    public List<HolidaySearchResponse> Results { get; }
}