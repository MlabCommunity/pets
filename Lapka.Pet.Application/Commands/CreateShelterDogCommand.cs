using Convey.CQRS.Commands;
using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Commands;

public record CreateShelterDogCommand(Guid PrincipalId, string ProfilePhoto, string Description, bool IsVisible,
    string Name, Gender Gender, double Age,
    bool IsSterilized,
    double Weight, DogColor DogColor, DogBreed DogBreed, ICollection<string> Photos) : ICommand;