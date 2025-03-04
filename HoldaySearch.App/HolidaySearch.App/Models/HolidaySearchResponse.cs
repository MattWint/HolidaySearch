namespace HolidaySearch.App;

public record HolidaySearchResponse
{
    public Flight Flight { get; set; }
    public Hotel Hotel { get; set; }
}