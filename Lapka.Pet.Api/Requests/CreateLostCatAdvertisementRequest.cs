using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Api.Requests;

public record CreateLostCatAdvertisementRequest(string Name, Gender Gender, DateTime DateOfBirth, bool IsSterilized,
    double Weight,
    CatColor CatColor, CatBreed CatBreed, string Description, bool IsVisible, DateTime DateOfDisappearance,
    string CityOfDisappearance, string StreetOfDisappearance);