namespace Lapka.Pet.Api.Requests;

public record UpdateShelterRequest(string Street, string City, string ZipCode, string OrganizationName, string Krs,
    string Nip);