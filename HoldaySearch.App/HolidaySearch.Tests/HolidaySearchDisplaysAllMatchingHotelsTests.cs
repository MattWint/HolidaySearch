using HolidaySearch.App;
using Shouldly;

namespace HolidaySearch.Tests;

public class HolidaySearchDisplaysAllMatchingHotelsTests
{
    [Test]
    [TestCaseSource(nameof(HotelPairsTestCases))]
    [Description("Ensure each hotel is paired with each flight. E.g. if there's two hotels, pair with two flights means 4 results." +
                 "The consumer (UI) could then display each hotel once with the ability to edit the flight")]
    public void ShouldMatchAllHotelsWithFlights_WhenMultipleHotelsMatchCriteria(HolidaySearchRequest request, (int flightId, int hotelId)[] combinations)
    {
        var holidaySearch = new App.HolidaySearch(request);
        
        holidaySearch.Results.Count.ShouldBe(combinations.Length);

        for (var i = 0; i < holidaySearch.Results.Count; i++)
        {
            var searchResult = holidaySearch.Results[i];
            var expectedResult = combinations[i];
            
            searchResult.Flight.Id.ShouldBe(expectedResult.flightId);
            searchResult.Hotel.Id.ShouldBe(expectedResult.hotelId);
        }
    }
    
    private static IEnumerable<TestCaseData> HotelPairsTestCases()
    {
        yield return new TestCaseData(
            new HolidaySearchRequest
                { DepartingFrom = "MAN", ArrivingAt = "PMI", DepartureDate = new DateTime(2023, 6, 15), Duration = 10 },
            new (int flightId, int hotelId)[]
            {
                (5, 5),
                (5, 13),
                (3, 5),
                (3, 13)
            }
        ).SetName("Manchester to Mallorca");
    }
}