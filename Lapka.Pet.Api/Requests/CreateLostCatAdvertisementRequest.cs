using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Api.Requests;

public record CreateLostCatAdvertisementRequest(string Name,Guid ProfilePhotoId, Gender Gender, DateTime DateOfBirth, bool IsSterilized,
    double Weight,
    CatColor CatColor, CatBreed CatBreed,ICollection<Guid> Photos,string Description, string FirstName,
    string PhoneNumber, bool IsVisible, DateTime DateOfDisappearance,double Longitude,double Latitude);