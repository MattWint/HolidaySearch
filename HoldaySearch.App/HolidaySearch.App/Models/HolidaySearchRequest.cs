namespace HolidaySearch.App;

public record HolidaySearchRequest
{
    public string DepartingFrom { get; set; }
    public string ArrivingAt { get; set; }
    public DateTime? DepartureDate { get; set; }
    public int Duration { get; set; }
}