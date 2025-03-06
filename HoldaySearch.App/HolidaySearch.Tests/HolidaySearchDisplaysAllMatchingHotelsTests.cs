using HolidaySearch.App;
using Shouldly;

namespace HolidaySearch.Tests;

public class HolidaySearchDisplaysAllMatchingHotelsTests
{
    [Test]
    [TestCaseSource(nameof(HotelPairsTestCases))]
    [Description("Ensure each hotel is paired with each flight. E.g. if there's two hotels, pair with two flights means 4 results." +
                 "The consumer (UI) could then display each hotel once with the ability to edit the flight")]
    public void ShouldMatchAllHotelsWithFlights_AndOrderByBestValue_WhenMultipleHotelsMatchCriteria(HolidaySearchRequest request, (int flightId, int hotelId)[] combinations)
    {
        var holidaySearch = HolidaySearchFactory.CreateDefault();

        var results = holidaySearch.Search(request);
        
        results.Count.ShouldBe(combinations.Length);

        for (var i = 0; i < results.Count; i++)
        {
            var searchResult = results[i];
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
                (5, 5), // 130 + (10 * 60) 
                (3, 5), // 170 + (10 * 60)
                (5, 13), // 130 + 10 * 295)
                (3, 13) // 170 + (10 * 295)
            }
        ).SetName("Manchester to Mallorca");
    }
}