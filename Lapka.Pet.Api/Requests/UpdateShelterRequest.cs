namespace Lapka.Pet.Api.Requests;

public record UpdateShelterRequest(double Longitude,double Latitude, string OrganizationName,string PhoneNumber, string Krs,
    string Nip);