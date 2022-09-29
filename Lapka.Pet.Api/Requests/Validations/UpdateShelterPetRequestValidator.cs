using FluentValidation;

namespace Lapka.Pet.Api.Requests.Validations;

internal sealed class UpdateShelterPetRequestValidator: AbstractValidator<UpdateShelterPetRequest>
{
    public UpdateShelterPetRequestValidator()
    {
        RuleFor(x => x.Description)
            .NotNull()
            .NotEmpty()
            .MaximumLength(510);
        
        RuleFor(x => x.PetName)
            .NotNull()
            .NotEmpty()
            .MaximumLength(20);
        
        RuleFor(x => x.Weight)
            .InclusiveBetween(0, 200);
    }
}