using Convey.CQRS.Commands;
using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Application.Commands;

public record CreateCatCommand(Guid OwnerId, string Name, Gender Gender, DateTime DateOfBirth, bool IsSterilized,
    double Weight, CatColor CatColor, CatBreed CatBreed) : ICommand;