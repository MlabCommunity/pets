using Convey.CQRS.Commands;
using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Commands;

public record CreateOtherPetCommand(Guid OwnerId,Guid ProfilePhotoId,string Name, Gender Gender, DateTime DateOfBirth, bool IsSterilized,
    double Weight, ICollection<Guid> Photos) : ICommand;