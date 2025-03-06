using FluentValidation;

namespace HolidaySearch.App;

public class HolidaySearchRequestValidator : AbstractValidator<HolidaySearchRequest>
{
    public HolidaySearchRequestValidator()
    {
        RuleFor(x => x.Duration)
            .GreaterThan(0)
            .WithMessage("Duration must be greater than zero.");

        RuleFor(x => x.DepartureDate)
            .NotEqual(default(DateTime))
            .WithMessage("Departure date is required.");
    }
}