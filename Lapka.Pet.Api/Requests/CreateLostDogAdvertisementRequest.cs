using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Api.Requests;

public record CreateLostDogAdvertisementRequest(string Name, Gender Gender, DateTime DateOfBirth, bool IsSterilized,
    double Weight,
    DogColor DogColor, DogBreed DogBreed, string Description, bool IsVisible, DateTime DateOfDisappearance,
    string CityOfDisappearance, string StreetOfDisappearance,ICollection<Guid> Photos);