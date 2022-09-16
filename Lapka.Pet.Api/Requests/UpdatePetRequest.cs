namespace Lapka.Pet.Api.Requests;

public record UpdatePetRequest(Guid PetId, string Name, bool IsSterilized, double Weight,string Description);