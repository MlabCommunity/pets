using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Api.Requests;

public record CreateLostOtherPetAdvertisementRequest(Guid OwnerId, Guid ProfilePhotoId, string Name, Gender Gender,
    DateTime DateOfBirth, bool IsSterilized,
    double Weight, ICollection<Guid> Photos, string Description, string FirstName,
    string PhoneNumber, bool IsVisible, DateTime DateOfDisappearance, double Longitude, double Latitude);