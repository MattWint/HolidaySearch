namespace HolidaySearch.App.Models;

public record HolidaySearchRequest
{
    public required string DepartingFrom { get; init; }
    public required string ArrivingAt { get; init; }
    public DateTime? DepartureDate { get; init; }
    public int Duration { get; init; }
}