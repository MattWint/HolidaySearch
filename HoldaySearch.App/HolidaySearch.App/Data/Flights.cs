namespace HolidaySearch.App.Data;

/// <summary>
/// I don't think deserialising JSON is something you're interested in
/// So I'm going to simplify by loading into C#.
/// This also gives us compile-time safety.
/// Sorry if you were interested in JSON deserialisation :(
/// </summary>
public static class Flights
{
    public static readonly List<Flight> Data =
    [
        new()
        {
            Id = 1, Airline = "First Class Air", From = "MAN", To = "TFS", Price = 470,
            DepartureDate = new DateTime(2023, 7, 1)
        },
        new()
        {
            Id = 2, Airline = "Oceanic Airlines", From = "MAN", To = "AGP", Price = 245,
            DepartureDate = new DateTime(2023, 7, 1)
        },
        new()
        {
            Id = 3, Airline = "Trans American Airlines", From = "MAN", To = "PMI", Price = 170,
            DepartureDate = new DateTime(2023, 6, 15)
        },
        new()
        {
            Id = 4, Airline = "Trans American Airlines", From = "LTN", To = "PMI", Price = 153,
            DepartureDate = new DateTime(2023, 6, 15)
        },
        new()
        {
            Id = 5, Airline = "Fresh Airways", From = "MAN", To = "PMI", Price = 130,
            DepartureDate = new DateTime(2023, 6, 15)
        },
        new()
        {
            Id = 6, Airline = "Fresh Airways", From = "LGW", To = "PMI", Price = 75,
            DepartureDate = new DateTime(2023, 6, 15)
        },
        new()
        {
            Id = 7, Airline = "Trans American Airlines", From = "MAN", To = "LPA", Price = 125,
            DepartureDate = new DateTime(2022, 11, 10)
        },
        new()
        {
            Id = 8, Airline = "Fresh Airways", From = "MAN", To = "LPA", Price = 175,
            DepartureDate = new DateTime(2023, 11, 10)
        },
        new()
        {
            Id = 9, Airline = "Fresh Airways", From = "MAN", To = "AGP", Price = 140,
            DepartureDate = new DateTime(2023, 4, 11)
        },
        new()
        {
            Id = 10, Airline = "First Class Air", From = "LGW", To = "AGP", Price = 225,
            DepartureDate = new DateTime(2023, 7, 1)
        },
        new()
        {
            Id = 11, Airline = "First Class Air", From = "LGW", To = "AGP", Price = 155,
            DepartureDate = new DateTime(2023, 7, 1)
        },
        new()
        {
            Id = 12, Airline = "Trans American Airlines", From = "MAN", To = "AGP", Price = 202,
            DepartureDate = new DateTime(2023, 10, 25)
        }
    ];
}