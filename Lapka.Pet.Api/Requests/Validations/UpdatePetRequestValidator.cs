using FluentValidation;

namespace Lapka.Pet.Api.Requests.Validations;

internal sealed class UpdatePetRequestValidator : AbstractValidator<UpdatePetRequest>
{
    public UpdatePetRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.Weight)
            .InclusiveBetween(0, 200);
    }
}