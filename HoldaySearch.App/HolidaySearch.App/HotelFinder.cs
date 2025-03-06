using HolidaySearch.App.Contracts;

namespace HolidaySearch.App;

public class HotelFinder() : IHotelFinder
{
    public IEnumerable<Hotel> FindHotels(HolidaySearchRequest request, IEnumerable<Hotel> hotels)
    {
        return hotels
            .Where(x => x.ArrivalDate == request.DepartureDate && x.Nights == request.Duration)
            .DistinctBy(x => x.Name);
    }
}