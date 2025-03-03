using Shouldly;

namespace HolidaySearch.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCaseSource(nameof(HolidayTestCases))]
    public void ShouldReturn(HolidaySearchRequest request, HolidaySearchResponse response)
    {
        var holidaySearch = new HolidaySearch("flights.json", "holidays.json", request);

        var topSearchResult = holidaySearch.Results.First();

        topSearchResult.ShouldBeEquivalentTo(response);
    }

    private static IEnumerable<TestCaseData> HolidayTestCases()
    {
        yield return new TestCaseData(
            new HolidaySearchRequest { DepartingFrom = "MAN", ArrivingAt = "AGP", DepartureDate = new DateTime(2023, 07, 01), Duration = 7 },
            new HolidaySearchResponse
            {
                Flight = new Flight { Id = 2, Airline = "Oceanic Airlines", DepartingFrom = "MAN", ArrivingAt = "AGP", Price = 245, DepartureDate = new DateTime(2023, 07, 01) },
                Hotel = new Hotel { Id = 9, Name = "Nh Malaga", ArrivalDate = new DateTime(2023, 07, 01), PricePerNight = 83, LocalAirports = ["AGP"], Nights = 7 }
            }
        ).SetName("Holiday Search 1");
        
        yield return new TestCaseData(
            new HolidaySearchRequest { DepartingFrom = "London", ArrivingAt = "PMI", DepartureDate = new DateTime(2023, 06, 15), Duration = 10 },
            new HolidaySearchResponse
            {
                Flight = new Flight { Id = 6, Airline = "Fresh Airways", DepartingFrom = "LGW", ArrivingAt = "PMI", Price = 75, DepartureDate = new DateTime(2023, 06, 15) },
                Hotel = new Hotel { Id = 5, Name = "Sol Katmandu Resort & Park", ArrivalDate = new DateTime(2023, 06, 15), PricePerNight = 60, LocalAirports = ["PMI"], Nights = 10 }
            }
        ).SetName("Holiday Search 2");
    
        yield return new TestCaseData(
            new HolidaySearchRequest { DepartingFrom = "", ArrivingAt = "LPA", DepartureDate = new DateTime(2022, 01, 10), Duration = 14 },
            new HolidaySearchResponse
            {
                Flight = new Flight { Id = 7, Airline = "Trans American Airlines", DepartingFrom = "MAN", ArrivingAt = "LPA", Price = 125, DepartureDate = new DateTime(2022, 11, 10) },
                Hotel = new Hotel { Id = 7, Name = "Club Maspalomas Suites and Spa", ArrivalDate = new DateTime(2022, 11, 10), PricePerNight = 75, LocalAirports = ["LPA"], Nights = 14 }
            }
        ).SetName("Holiday Search 3");
    }
}

public class HolidaySearch
{
    public HolidaySearch(string flightsDataPath, string hotelDataPath, HolidaySearchRequest request)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<HolidaySearchResponse> Results { get; set; }
}



public record HolidaySearchResponse
{
    public Flight Flight { get; set; }
    public Hotel Hotel { get; set; }
}

public record Hotel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string[] LocalAirports { get; set; }
    public decimal PricePerNight { get; set; }
    public int Nights { get; set; }
    public DateTime ArrivalDate { get; set; }
}

public record Flight
{
    public int Id { get; set; }
    public string DepartingFrom { get; set; }
    public string ArrivingAt { get; set; }
    public decimal Price { get; set; }
    public string Airline { get; set; }
    public DateTime DepartureDate { get; set; }
}

public record HolidaySearchRequest
{
    public string DepartingFrom { get; set; }
    public string ArrivingAt { get; set; }
    public DateTime DepartureDate { get; set; }
    public int Duration { get; set; }
}