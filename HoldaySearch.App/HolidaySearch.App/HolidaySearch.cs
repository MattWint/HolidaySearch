
using FluentValidation;
using HolidaySearch.App.Contracts;

namespace HolidaySearch.App;

public class HolidaySearch(
    IFlightFinder flightFinder,
    IHotelFinder hotelFinder,
    IValidator<HolidaySearchRequest> validator,
    IEnumerable<Flight> flightData,
    IEnumerable<Hotel> hotelData)
{
    public List<HolidaySearchResponse> Search(HolidaySearchRequest request)
    {
        ValidateRequest(request);

        var flights = flightFinder.FindFlights(request, flightData);
        var hotels = hotelFinder.FindHotels(request, hotelData);

        var results = hotels
                // Join up matching hotels and flights
            .SelectMany(_ => flights, (hotel, flight) => new HolidaySearchResponse
            {
                Hotel = hotel,
                Flight = flight
            })
            .OrderBy(x => x.Flight.Price + x.Hotel.PricePerNight) // Number of nights is constant for a given search
            .ToList();

        return results;
    }
    
    private void ValidateRequest(HolidaySearchRequest request)
    {
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
        }
    }
}