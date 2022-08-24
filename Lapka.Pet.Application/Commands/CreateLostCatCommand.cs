using Convey.CQRS.Commands;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Application.Commands;

public record CreateLostCatCommand(Guid OwnerId, string Name, Gender Gender, DateTime DateOfBirth, bool IsSterilized,
    double Weight, CatColor CatColor, CatBreed CatBreed,ICollection<Guid> Photos) : ICommand;