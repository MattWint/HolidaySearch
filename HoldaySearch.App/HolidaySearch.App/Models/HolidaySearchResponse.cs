namespace HolidaySearch.App.Models;

public record HolidaySearchResponse
{
    public required Flight Flight { get; init; }
    public required Hotel Hotel { get; init; }
}