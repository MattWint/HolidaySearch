using HolidaySearch.App;
using HolidaySearch.App.Data;

namespace HolidaySearch.Tests;

public static class HolidaySearchFactory
{
    public static App.HolidaySearch CreateDefault()
    {
        var airportResolver = new AirportResolver();
        var flightFinder = new FlightFinder(airportResolver);
        var hotelFinder = new HotelFinder();
        var validator = new HolidaySearchRequestValidator();
        var flightData = Flights.Data;
        var hotelData = Hotels.Data;

        return new App.HolidaySearch(flightFinder, hotelFinder, validator, flightData, hotelData);
    }
}