using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record CreateShelterCommand(Guid UserId, string Email, string OrganizationName, string Street,
    string ZipCode, string City, string Nip, string Krs) : ICommand;