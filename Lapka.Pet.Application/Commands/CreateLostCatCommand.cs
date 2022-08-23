using Convey.CQRS.Commands;
using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Commands.Handlers;

public record CreateLostCatCommand(Guid OwnerId, string Name, Gender Gender, DateTime DateOfBirth, bool IsSterilized,
    double Weight, CatColor CatColor, CatBreed CatBreed) : ICommand;