using FluentValidation;

namespace Lapka.Pet.Api.Requests.Validations;

internal sealed class CreateLostCatAdvertisementRequestValidator : AbstractValidator<CreateLostCatAdvertisementRequest>
{
    public CreateLostCatAdvertisementRequestValidator()
    {
        RuleFor(x => x.Description)
            .NotNull()
            .NotEmpty()
            .MaximumLength(510);

        RuleFor(x => x.Longitude)
            .InclusiveBetween(14.07, 24.15);

        RuleFor(x => x.Latitude)
            .InclusiveBetween(49.00, 55.34);

        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(20);
        
        RuleFor(x => x.FirstName)
            .NotNull()
            .NotEmpty()
            .MaximumLength(20);
        
        RuleFor(shelter => shelter.PhoneNumber)
            .NotEmpty()
            .Matches(RegexRules.PhoneNumberRule)
            .WithMessage("Phone Number must be 9 or 10-digit number");
        
        RuleFor(x => x.DateOfBirth)
            .NotNull()
            .InclusiveBetween(DateTime.UtcNow.AddYears(-50), DateTime.UtcNow);
        
        RuleFor(x => x.DateOfDisappearance)
            .NotNull()
            .InclusiveBetween(DateTime.UtcNow.AddYears(-50), DateTime.UtcNow);
        
        RuleFor(x => x.Weight)
            .InclusiveBetween(0, 200);
        
    }
}