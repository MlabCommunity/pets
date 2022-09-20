using Convey.CQRS.Commands;
using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Commands;

public record CreateLostDogCommand(Guid OwnerId,string ProfilePhoto, string Name, Gender Gender, DateTime DateOfBirth, bool IsSterilized,
    double Weight, DogColor DogColor, DogBreed DogBreed, ICollection<string> Photos,string Description, string FirstName,
string PhoneNumber, bool IsVisible, DateTime DateOfDisappearance,double Longitude,double Latitude) : ICommand;