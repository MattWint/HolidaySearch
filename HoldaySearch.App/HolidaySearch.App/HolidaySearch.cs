using HolidaySearch.App.Data;

namespace HolidaySearch.App;

public class HolidaySearch
{
    private IEnumerable<Flight> _flightData;
    private IEnumerable<Hotel> _hotelData;
    
    private readonly Dictionary<string, string[]> _cityToAirports = new()
    {
        { "London", ["LGW", "LTN"] },
    };
    
    public HolidaySearch(IEnumerable<Flight> flightData, IEnumerable<Hotel> hotelData, HolidaySearchRequest request)
    {
        _flightData = flightData;
        _hotelData = hotelData;

        if (request.Duration == 0)
        {
            throw new ArgumentException("Duration must be greater than 0");
        }
        
        FindFlights(request);
        FindHotels(request);
        
        Results = _hotelData
            .SelectMany(_ => _flightData, (hotel, flight) => new HolidaySearchResponse
            {
                Hotel = hotel,
                Flight = flight
            })
            .OrderBy(x => x.Flight.Price + x.Hotel.PricePerNight) // Duration is constant for a given search so we don't need to factor it into the price
            .ToList();
    }

    private void FindHotels(HolidaySearchRequest request)
    {
        _hotelData = _hotelData.Where(x => x.ArrivalDate == request.DepartureDate);
        _hotelData = _hotelData.Where(x => x.Nights == request.Duration);
        _hotelData = _hotelData.DistinctBy(x => x.Name);
    }

    private void FindFlights(HolidaySearchRequest request)
    {
        _flightData = _flightData.Where(x => x.DepartureDate == request.DepartureDate);

        if (!string.IsNullOrWhiteSpace(request.DepartingFrom))
        {
            if (_cityToAirports.TryGetValue(request.DepartingFrom, out var airports))
            {
                _flightData = _flightData.Where(x => airports.Contains(x.From));
            }
            else
            {
                _flightData = _flightData.Where(x => x.From == request.DepartingFrom);
            }
        }

        _flightData = _flightData.Where(x => x.To == request.ArrivingAt);
    }

    public List<HolidaySearchResponse> Results { get; }
}