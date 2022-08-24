using Convey.CQRS.Commands;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Application.Commands;

public record CreateLostDogCommand(Guid OwnerId, string Name, Gender Gender, DateTime DateOfBirth, bool IsSterilized,
    double Weight, DogColor DogColor, DogBreed DogBreed,ICollection<Guid> Photos) : ICommand;