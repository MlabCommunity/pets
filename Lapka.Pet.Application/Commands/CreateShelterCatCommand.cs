using Convey.CQRS.Commands;
using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Commands;

public record CreateShelterCatCommand(Guid PrincipalId, string Name, Gender Gender, DateTime DateOfBirth,
    bool IsSterilized,
    double Weight, CatColor CatColor, CatBreed CatBreed, ICollection<Guid> Photos) : ICommand;