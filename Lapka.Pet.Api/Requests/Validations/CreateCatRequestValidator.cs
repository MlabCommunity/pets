using FluentValidation;

namespace Lapka.Pet.Api.Requests.Validations;

internal sealed class CreateCatRequestValidator : AbstractValidator<CreateCatRequest>
{
    public CreateCatRequestValidator()
    {
        RuleFor(x => x.Weight)
            .NotNull()
            .InclusiveBetween(0, 200);

        RuleFor(x => x.DateOfBirth)
            .NotNull()
            .InclusiveBetween(DateTime.UtcNow.AddYears(-50), DateTime.UtcNow);
    }
}