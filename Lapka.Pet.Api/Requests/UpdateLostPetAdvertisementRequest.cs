namespace Lapka.Pet.Api.Requests;

public record UpdateLostPetAdvertisementRequest(string Description,string Name,bool IsSterilized,double Weight);