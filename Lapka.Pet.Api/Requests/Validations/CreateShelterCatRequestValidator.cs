using FluentValidation;

namespace Lapka.Pet.Api.Requests.Validations;

internal sealed class CreateShelterCatRequestValidator : AbstractValidator<CreateShelterCatRequest>
{
    public CreateShelterCatRequestValidator()
    {
  
        RuleFor(x => x.Description)
            .NotNull()
            .NotEmpty()
            .MaximumLength(510);
        
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