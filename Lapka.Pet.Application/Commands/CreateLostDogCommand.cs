using Convey.CQRS.Commands;
using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Commands;

public record CreateLostDogCommand(Guid OwnerId,Guid ProfilePhotoId, string Name, Gender Gender, DateTime DateOfBirth, bool IsSterilized,
    double Weight, DogColor DogColor, DogBreed DogBreed, ICollection<Guid> Photos,string Description, string FirstName,
string PhoneNumber, bool IsVisible, DateTime DateOfDisappearance,double Longitude,double Latitude) : ICommand;