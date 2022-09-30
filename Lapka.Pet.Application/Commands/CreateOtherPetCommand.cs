using Convey.CQRS.Commands;
using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Commands;

public record CreateOtherPetCommand(Guid OwnerId, string ProfilePhotoId, string Name, Gender Gender,
    DateTime DateOfBirth, bool IsSterilized,
    double Weight, ICollection<string> Photos) : ICommand;