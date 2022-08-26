namespace Lapka.Pet.Api.Requests;

public record CreateShelterAdvertisementRequest(Guid PetId, string Description,
    bool IsVisible);