using Newtonsoft.Json;

namespace HolidaySearch.App;

public record Hotel
{
    public int Id { get; set; }
    public string Name { get; set; }
    [JsonProperty("arrival_date")] public DateTime ArrivalDate { get; set; }
    [JsonProperty("local_airports")] public string[] LocalAirports { get; set; }

    [JsonProperty("price_per_night")] public decimal PricePerNight { get; set; }
    public int Nights { get; set; }
}