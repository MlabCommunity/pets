using Convey.CQRS.Commands;
using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Commands;

public record CreateShelterDogCommand(Guid PrincipalId, string Name, Gender Gender, DateTime DateOfBirth,
    bool IsSterilized,
    double Weight, DogColor DogColor, DogBreed DogBreed, ICollection<Guid> Photos) : ICommand;