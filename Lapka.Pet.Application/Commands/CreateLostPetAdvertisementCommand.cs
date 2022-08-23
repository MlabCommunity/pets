using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record CreateLostPetAdvertisementCommand(Guid PetId, string Description, bool IsVisible,
    DateTime DateOfDisappearance,
    string CityOfDisappearance, string StreetOfDisappearance) : ICommand;