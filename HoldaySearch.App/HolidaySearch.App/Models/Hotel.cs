namespace HolidaySearch.App.Models;

public record Hotel
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required DateTime ArrivalDate { get; init; }
    public required string[] LocalAirports { get; set; }
    public required decimal PricePerNight { get; init; }
    public int Nights { get; init; }
}