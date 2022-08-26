using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record UpdateShelterCommand(Guid UserId, string Street, string City, string ZipCode, string OrganizationName,
    string Krs,
    string Nip) : ICommand;