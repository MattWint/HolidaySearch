namespace HolidaySearch.App.Contracts;

public interface IHotelFinder
{
    IEnumerable<Hotel> FindHotels(HolidaySearchRequest request, IEnumerable<Hotel> hotels);
}