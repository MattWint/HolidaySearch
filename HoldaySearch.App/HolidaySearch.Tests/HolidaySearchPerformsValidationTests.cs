using HolidaySearch.App;
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
        
        var holidaySearch = HolidaySearchFactory.CreateDefault();

        Should.Throw<ArgumentException>(() =>
            holidaySearch.Search(request)
        );
    }
    
    [Test]
    public void ShouldReturnError_WhenDepartureDateIsMissing()
    {
        var request = new HolidaySearchRequest
        {
            ArrivingAt = "LGW",
            DepartingFrom = "LTN",
            DepartureDate = default(DateTime),
            Duration = 10
        };
        
        var holidaySearch = HolidaySearchFactory.CreateDefault();

        Should.Throw<ArgumentException>(() =>
            holidaySearch.Search(request)
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
        
        var holidaySearch = HolidaySearchFactory.CreateDefault();
        
        holidaySearch.Search(request).ShouldBeEmpty();
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

        var holidaySearch = HolidaySearchFactory.CreateDefault();

        holidaySearch.Search(request).ShouldBeEmpty();
    }
}