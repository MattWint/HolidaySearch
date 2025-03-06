using FluentValidation;

namespace HolidaySearch.App;

public class HolidaySearchRequestValidator : AbstractValidator<HolidaySearchRequest>
{
    public HolidaySearchRequestValidator()
    {
        RuleFor(x => x.Duration)
            .GreaterThan(0)
            .WithMessage("Duration greater than 0 is required.");
    }
}