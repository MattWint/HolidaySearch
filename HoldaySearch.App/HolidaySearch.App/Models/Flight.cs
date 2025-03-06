
namespace HolidaySearch.App.Models;

public record Flight
{
    public required int Id { get; init; }
    public required string From { get; init; }
    public required string To { get; init; }
    public required decimal Price { get; init; }
    public required string Airline { get; set; }
    public required DateTime DepartureDate { get; init; }
}