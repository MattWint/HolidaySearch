using HolidaySearch.App;
using HolidaySearch.App.Data;
using Shouldly;

namespace HolidaySearch.Tests;

public class HolidaySearchDoesNotContainDuplicates
{
    [Test]
    [Description("Given that the arrival date and duration are required values, we should not be getting a given hotel more than once")]
    public void ShouldNotContainDuplicates_WhenSearchSubmitted()
    {
        var request = new HolidaySearchRequest
        {
            ArrivingAt = "PMI",
            DepartureDate = new DateTime(2023, 06, 15),
            Duration = 14
        };
        
        var holidaySearch = new App.HolidaySearch(Flights.Data, Hotels.Data, request);

        var hotels = new HashSet<string>();

        foreach (var holiday in holidaySearch.Results)
        {
            hotels.ShouldNotContain(holiday.Hotel.Name);
            hotels.Add(holiday.Hotel.Name);
        }
    }
}