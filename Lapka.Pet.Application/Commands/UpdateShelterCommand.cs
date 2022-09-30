using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record UpdateShelterCommand(Guid UserId, double Longitude, double Latitude, string PhoneNumber,
    string OrganizationName,
    string Krs, string Nip) : ICommand;