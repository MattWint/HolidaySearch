﻿using HolidaySearch.App;
using HolidaySearch.App.Data;
using HolidaySearch.App.Models;
using Shouldly;

namespace HolidaySearch.Tests;

public class HolidaySearchFindsBestMatchTest
{
    [Test]
    [Description("Returns best match with fully populated holiday response object")]
    [TestCaseSource(nameof(HolidayBestMatchTestCases))]
    public void ShouldReturnExpectedSearchResults_WhenRequestPopulated(HolidaySearchRequest request, HolidaySearchResponse response)
    {
        var holidaySearch = HolidaySearchFactory.CreateDefault();

        var results = holidaySearch.Search(request);

        var topSearchResult = results.First();

        topSearchResult.ShouldBeEquivalentTo(response);
    }

    private static IEnumerable<TestCaseData> HolidayBestMatchTestCases()
    {
        yield return new TestCaseData(
            new HolidaySearchRequest
                { DepartingFrom = "MAN", ArrivingAt = "AGP", DepartureDate = new DateTime(2023, 07, 01), Duration = 7 },
            new HolidaySearchResponse
            {
                Flight = Flights.Data.First(x => x.Id ==  2),
                Hotel = Hotels.Data.First(x => x.Id == 9)
            }
        ).SetName("London to Malaga");

        yield return new TestCaseData(
            new HolidaySearchRequest
            {
                DepartingFrom = "London", ArrivingAt = "PMI", DepartureDate = new DateTime(2023, 06, 15), Duration = 10
            },
            new HolidaySearchResponse
            {
                Flight = Flights.Data.First(x => x.Id ==  6),
                Hotel = Hotels.Data.First(x => x.Id ==  5)
            }
        ).SetName("Any London airport to Mallorca");

        yield return new TestCaseData(
            new HolidaySearchRequest
                { DepartingFrom = "", ArrivingAt = "LPA", DepartureDate = new DateTime(2022, 11, 10), Duration = 14 },
            new HolidaySearchResponse
            {
                Flight = Flights.Data.First(x => x.Id ==  7),
                Hotel = Hotels.Data.First(x => x.Id == 6)
            }
        ).SetName("Any airport to Gran Canaria");
    }
}