using FluentValidation;

namespace Lapka.Pet.Api.Requests.Validations;

internal sealed class UpdateShelterRequestValidator : AbstractValidator<UpdateShelterRequest>
{
    public UpdateShelterRequestValidator()
    {
        RuleFor(shelter => shelter.Longitude)
            .NotEmpty()
            .InclusiveBetween(14.07, 24.15);

        RuleFor(shelter => shelter.Latitude)
            .NotEmpty()
            .InclusiveBetween(49.00, 55.34);

        RuleFor(shelter => shelter.Nip)
            .NotEmpty()
            .Matches(RegexRules.NipKrsRule)
            .WithMessage("NIP must be 10-digit number");

        RuleFor(shelter => shelter.Krs)
            .NotEmpty()
            .Matches(RegexRules.NipKrsRule)
            .WithMessage("NIP must be 10-digit number");

        RuleFor(shelter => shelter.PhoneNumber)
            .NotEmpty()
            .Matches(RegexRules.PhoneNumberRule)
            .WithMessage("Phone Number must be 9 or 10-digit number");

        RuleFor(x => x.OrganizationName)
            .NotEmpty()
            .NotNull()
            .MaximumLength(100);
    }
}