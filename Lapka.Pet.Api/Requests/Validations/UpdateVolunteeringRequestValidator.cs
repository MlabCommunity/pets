using FluentValidation;

namespace Lapka.Pet.Api.Requests.Validations;

internal sealed class UpdateVolunteeringRequestValidator : AbstractValidator<UpdateVolunteeringRequest>
{
    public UpdateVolunteeringRequestValidator()
    {
        RuleFor(x => x.DonationDescription)
            .NotNull()
            .MaximumLength(1500);
        
        RuleFor(x => x.DailyHelpDescription)
            .NotNull()
            .MaximumLength(1500);
        
        RuleFor(x => x.TakingDogsOutDescription)
            .NotNull()
            .MaximumLength(1500);

        RuleFor(x => x.BankAccountNumber)
            .Matches(RegexRules.PhoneNumberRule);
    }
}