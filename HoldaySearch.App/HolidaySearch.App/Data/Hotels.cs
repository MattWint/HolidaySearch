namespace HolidaySearch.App.Data;

/// <summary>
/// See comment on <see cref="Flights"/> regarding why the JSOn is now C#
/// </summary>
public static class Hotels
{
    public static List<Hotel> Data =
    [
        new()
        {
            Id = 1, Name = "Iberostar Grand Portals Nous", ArrivalDate = new DateTime(2022, 11, 5), PricePerNight = 100,
            LocalAirports = [ "TFS" ], Nights = 7
        },

        new()
        {
            Id = 2, Name = "Laguna Park 2", ArrivalDate = new DateTime(2022, 11, 5), PricePerNight = 50,
            LocalAirports = [ "TFS" ], Nights = 7
        },

        new()
        {
            Id = 3, Name = "Sol Katmandu Park & Resort", ArrivalDate = new DateTime(2023, 6, 15), PricePerNight = 59,
            LocalAirports = [ "PMI" ], Nights = 14
        },

        new()
        {
            Id = 4, Name = "Sol Katmandu Park & Resort", ArrivalDate = new DateTime(2023, 6, 15), PricePerNight = 59,
            LocalAirports = [ "PMI" ], Nights = 14
        },

        new()
        {
            Id = 5, Name = "Sol Katmandu Park & Resort", ArrivalDate = new DateTime(2023, 6, 15), PricePerNight = 60,
            LocalAirports = [ "PMI" ], Nights = 10
        },

        new()
        {
            Id = 6, Name = "Club Maspalomas Suites and Spa", ArrivalDate = new DateTime(2022, 11, 10),
            PricePerNight = 75, LocalAirports = [ "LPA" ], Nights = 14
        },

        new()
        {
            Id = 7, Name = "Club Maspalomas Suites and Spa", ArrivalDate = new DateTime(2022, 9, 10),
            PricePerNight = 76, LocalAirports = [ "LPA" ], Nights = 14
        },

        new()
        {
            Id = 8, Name = "Boutique Hotel Cordial La Peregrina", ArrivalDate = new DateTime(2022, 10, 10),
            PricePerNight = 45, LocalAirports = [ "LPA" ], Nights = 7
        },

        new()
        {
            Id = 9, Name = "Nh Malaga", ArrivalDate = new DateTime(2023, 7, 1), PricePerNight = 83,
            LocalAirports = [ "AGP" ], Nights = 7
        },

        new()
        {
            Id = 10, Name = "Barcelo Malaga", ArrivalDate = new DateTime(2023, 7, 5), PricePerNight = 45,
            LocalAirports = [ "AGP" ], Nights = 10
        },

        new()
        {
            Id = 11, Name = "Parador De Malaga Gibralfaro", ArrivalDate = new DateTime(2023, 10, 16),
            PricePerNight = 100, LocalAirports = [ "AGP" ], Nights = 7
        },

        new()
        {
            Id = 12, Name = "MS Maestranza Hotel", ArrivalDate = new DateTime(2023, 7, 1), PricePerNight = 45,
            LocalAirports = [ "AGP" ], Nights = 14
        },

        new()
        {
            Id = 13, Name = "Jumeirah Port Soller", ArrivalDate = new DateTime(2023, 6, 15), PricePerNight = 295,
            LocalAirports = [ "PMI" ], Nights = 10
        }
    ];
}