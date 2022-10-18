using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record UpdateLostPetAdvertisementCommand(Guid PetId, Guid PrincipalId, string Description, string FirstName,
    string PhoneNumber, string PetName, bool IsSterilized, double Weight, List<string> Photos) : ICommand;