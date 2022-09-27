using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Api.Requests;

public record CreateLostCatAdvertisementRequest(string Name,string ProfilePhoto, Gender Gender, DateTime DateOfBirth, bool IsSterilized,
    double Weight,
    CatColor CatColor, CatBreed CatBreed,ICollection<string> Photos,string Description, string FirstName,
    string PhoneNumber, bool IsVisible, DateTime DateOfDisappearance,double Longitude,double Latitude);