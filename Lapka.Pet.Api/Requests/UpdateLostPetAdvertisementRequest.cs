namespace Lapka.Pet.Api.Requests;

public record UpdateLostPetAdvertisementRequest(string Description, string FirstName, string PhoneNumber, string Name,
    bool IsSterilized, double Weight);