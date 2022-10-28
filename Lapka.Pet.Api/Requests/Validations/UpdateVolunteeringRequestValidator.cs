using FluentValidation;

namespace Lapka.Pet.Api.Requests.Validations;

internal sealed class UpdateVolunteeringRequestValidator : AbstractValidator<UpdateVolunteeringRequest>
{
    public UpdateVolunteeringRequestValidator()
    {
        RuleFor(x => x.DonationDescription)
            .NotNull()
            .MaximumLength(100);

        RuleFor(x => x.DailyHelpDescription)
            .NotNull()
            .MaximumLength(100);

        RuleFor(x => x.TakingDogsOutDescription)
            .NotNull()
            .MaximumLength(100);

        RuleFor(x => x.BankAccountNumber)
            .Matches(RegexRules.BankAccountRule)
            .MaximumLength(26);
    }
}