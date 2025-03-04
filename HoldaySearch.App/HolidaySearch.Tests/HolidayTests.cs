using HolidaySearch.App;
using Shouldly;

namespace HolidaySearch.Tests;

public class Tests
{

    [Test]
    [TestCaseSource(nameof(HolidayTestCases))]
    public void ShouldReturn_ExpectedSearchResultsWhenRequestPopulated(HolidaySearchRequest request, HolidaySearchResponse response)
    {
        var holidaySearch = new App.HolidaySearch("flights.json", "hotels.json", request);

        var topSearchResult = holidaySearch.Results.First();

        topSearchResult.ShouldBeEquivalentTo(response);
    }

    private static IEnumerable<TestCaseData> HolidayTestCases()
    {
        yield return new TestCaseData(
            new HolidaySearchRequest
                { DepartingFrom = "MAN", ArrivingAt = "AGP", DepartureDate = new DateTime(2023, 07, 01), Duration = 7 },
            new HolidaySearchResponse
            {
                Flight = new Flight
                {
                    Id = 2, Airline = "Oceanic Airlines", From = "MAN", To = "AGP", Price = 245,
                    DepartureDate = new DateTime(2023, 07, 01)
                },
                Hotel = new Hotel
                {
                    Id = 9, Name = "Nh Malaga", ArrivalDate = new DateTime(2023, 07, 01), PricePerNight = 83,
                    LocalAirports = ["AGP"], Nights = 7
                }
            }
        ).SetName("Holiday Search 1");

        yield return new TestCaseData(
            new HolidaySearchRequest
            {
                DepartingFrom = "London", ArrivingAt = "PMI", DepartureDate = new DateTime(2023, 06, 15), Duration = 10
            },
            new HolidaySearchResponse
            {
                Flight = new Flight
                {
                    Id = 6, Airline = "Fresh Airways", From = "LGW", To = "PMI", Price = 75,
                    DepartureDate = new DateTime(2023, 06, 15)
                },
                Hotel = new Hotel
                {
                    Id = 5, Name = "Sol Katmandu Park & Resort", ArrivalDate = new DateTime(2023, 06, 15),
                    PricePerNight = 60, LocalAirports = ["PMI"], Nights = 10
                }
            }
        ).SetName("Holiday Search 2");

        yield return new TestCaseData(
            new HolidaySearchRequest
                { DepartingFrom = "", ArrivingAt = "LPA", DepartureDate = new DateTime(2022, 11, 10), Duration = 14 },
            new HolidaySearchResponse
            {
                Flight = new Flight
                {
                    Id = 7, Airline = "Trans American Airlines", From = "MAN", To = "LPA", Price = 125,
                    DepartureDate = new DateTime(2022, 11, 10)
                },
                Hotel = new Hotel
                {
                    Id = 6, Name = "Club Maspalomas Suites and Spa", ArrivalDate = new DateTime(2022, 11, 10),
                    PricePerNight = 75, LocalAirports = ["LPA"], Nights = 14
                }
            }
        ).SetName("Holiday Search 3");
    }
}