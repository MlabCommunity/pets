using Convey.CQRS.Commands;

namespace Lapka.Pet.Application.Commands;

public record CreateShelterCommand(Guid UserId, string Email, string FirstName, string LastName, string PhoneNumber,
    string OrganizationName, double Longitude, double Latitude,string Street,string City,string ZipCode, string Nip, string Krs) : ICommand;