﻿using HolidaySearch.App.Data;

namespace HolidaySearch.App;

public class HolidaySearch
{
    private IEnumerable<Flight> _flightsSearchResult;
    private IEnumerable<Hotel> _hotelSearchResult;
    
    private readonly Dictionary<string, string[]> _cityToAirports = new()
    {
        { "London", ["LGW", "LTN"] },
    };
    
    public HolidaySearch(IEnumerable<Flight> flightData, IEnumerable<Hotel> hotelData, HolidaySearchRequest request)
    {
        _flightsSearchResult = flightData;
        _hotelSearchResult = hotelData;
        
        FindFlights(request);
        FindHotels(request);
        
        Results = _hotelSearchResult
            .SelectMany(_ => _flightsSearchResult, (hotel, flight) => new HolidaySearchResponse
            {
                Hotel = hotel,
                Flight = flight
            })
            .OrderBy(x => x.Flight.Price + x.Hotel.PricePerNight) // Duration is constant for a given search so we don't need to factor it into the price
            .ToList();
    }

    private void FindHotels(HolidaySearchRequest request)
    {
        _hotelSearchResult = _hotelSearchResult.Where(x => x.ArrivalDate == request.DepartureDate);

        _hotelSearchResult = _hotelSearchResult.Where(x => x.Nights == request.Duration);
    }

    private void FindFlights(HolidaySearchRequest request)
    {
        _flightsSearchResult = _flightsSearchResult.Where(x => x.DepartureDate == request.DepartureDate);

        if (!string.IsNullOrWhiteSpace(request.DepartingFrom))
        {
            if (_cityToAirports.TryGetValue(request.DepartingFrom, out var airports))
            {
                _flightsSearchResult = _flightsSearchResult.Where(x => airports.Contains(x.From));
            }
            else
            {
                _flightsSearchResult = _flightsSearchResult.Where(x => x.From == request.DepartingFrom);
            }
        }

        _flightsSearchResult = _flightsSearchResult.Where(x => x.To == request.ArrivingAt);
    }

    public List<HolidaySearchResponse> Results { get; }
}