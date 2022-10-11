using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Api.Requests;

public record CreateLostDogAdvertisementRequest(string Name, string ProfilePhoto, Gender Gender, DateTime DateOfBirth,
    bool IsSterilized,
    double Weight, DogColor DogColor, DogBreed DogBreed, ICollection<string> Photos, string Description,
    string FirstName,
    string PhoneNumber, bool IsVisible, DateTime DateOfDisappearance, double Longitude, double Latitude,string City,string Street,string ZipCode);