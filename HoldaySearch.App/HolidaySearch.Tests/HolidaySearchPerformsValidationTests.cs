using HolidaySearch.App;
using HolidaySearch.App.Data;
using Shouldly;

namespace HolidaySearch.Tests;

public class HolidaySearchPerformsValidationTests
{
    [Test]
    public void ShouldReturnError_WhenDurationIsGreaterThanZero()
    {
        var request = new HolidaySearchRequest
        {
            ArrivingAt = "LGW",
            DepartingFrom = "LTN",
            DepartureDate = DateTime.Today,
            Duration = 0
        };

        Should.Throw<ArgumentException>(() =>
            new App.HolidaySearch(Flights.Data, Hotels.Data, request)
        );
    }
    
    [Test]
    public void ShouldReturnEmptyResult_WhenDepartingAirportDoesntExist()
    {
        var request = new HolidaySearchRequest
        {
            ArrivingAt = "LGW",
            DepartingFrom = "TTT",
            DepartureDate = DateTime.Today,
            Duration = 10
        };
        
        var holidaySearch = new App.HolidaySearch(Flights.Data, Hotels.Data, request);

        holidaySearch.Results.ShouldBeEmpty();
    }
    
    [Test]
    public void ShouldReturnEmptyResult_WhenArrivingAirportDoesntExist()
    {
        var request = new HolidaySearchRequest
        {
            ArrivingAt = "TTT",
            DepartingFrom = "PMI",
            DepartureDate = DateTime.Today,
            Duration = 10
        };
        
        var holidaySearch = new App.HolidaySearch(Flights.Data, Hotels.Data, request);

        holidaySearch.Results.ShouldBeEmpty();
    }
}