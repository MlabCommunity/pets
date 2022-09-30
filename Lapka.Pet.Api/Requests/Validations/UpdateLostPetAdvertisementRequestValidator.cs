using FluentValidation;

namespace Lapka.Pet.Api.Requests.Validations;

internal sealed class UpdateLostPetAdvertisementRequestValidator : AbstractValidator<UpdateLostPetAdvertisementRequest>
{
    public UpdateLostPetAdvertisementRequestValidator()
    {
        RuleFor(x => x.Description)
            .NotNull()
            .NotEmpty()
            .MaximumLength(510);

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

        RuleFor(x => x.Weight)
            .InclusiveBetween(0, 200);
    }
}