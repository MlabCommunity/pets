using Convey.CQRS.Commands;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Application.Commands;

public record CreatePetCommand(Guid OwnerId, string Name, Gender Gender, DateTime DateOfBirth, bool IsSterilized,
    double Weight, Object Breed, Object Color, PetType PetType) : ICommand;