using FluentValidation;

namespace Lapka.Pet.Api.Requests.Validations;

internal sealed class CreateDogRequestValidator : AbstractValidator<CreateDogRequest>
{
    public CreateDogRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(20);
        
        RuleFor(x => x.DateOfBirth)
            .NotNull()
            .InclusiveBetween(DateTime.UtcNow.AddYears(-50), DateTime.UtcNow);
        
        RuleFor(x => x.Weight)
            .InclusiveBetween(0, 200);
    }
}