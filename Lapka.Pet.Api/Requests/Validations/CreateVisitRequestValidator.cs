using FluentValidation;

namespace Lapka.Pet.Api.Requests.Validations;

internal sealed class CreateVisitRequestValidator : AbstractValidator<CreateVisitRequest>
{
    public CreateVisitRequestValidator()
    {
        RuleFor(x => x.Description)
            .NotNull()
            .NotEmpty()
            .MaximumLength(510);

        RuleFor(x => x.DateOfVisit)
            .InclusiveBetween(DateTime.UtcNow.AddYears(-50), DateTime.UtcNow.AddYears(5));

        RuleFor(x => x.WeightOnVisit)
            .InclusiveBetween(0, 200);
    }
}