namespace Lapka.Pet.Api.Requests;

public record UpdateShelterPetRequest(Guid PetId, string Description, string PetName, bool IsSterilized,
    double Weight);