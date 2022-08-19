using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Api.Requests;

public record CreateShelterAdvertisementRequest(Guid PetId, string Description, string PhoneNumber, string FirstName,bool IsVisible);