using HolidaySearch.App;
using HolidaySearch.App.Data;
using Shouldly;

namespace HolidaySearch.Tests;

public class HolidaySearchPerformsValidationTests
{
    [Test]
    public void ShouldEnsureDurationIsGreaterThanZero()
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
}