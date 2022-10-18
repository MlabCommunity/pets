using System.Data;
using FluentValidation;

namespace Lapka.Pet.Api.Requests.Validations;

public class CreateShelterCatRequestValidator : AbstractValidator<CreateShelterCatRequest>
{
    public CreateShelterCatRequestValidator()
    {
        RuleFor(x => x.Description)
            .NotNull()
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.Age)
            .NotNull()
            .InclusiveBetween(0, 50 * 12);

        RuleFor(x => x.Weight)
            .InclusiveBetween(0, 200);
    }
}