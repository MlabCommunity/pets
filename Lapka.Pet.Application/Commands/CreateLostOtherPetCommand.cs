using Convey.CQRS.Commands;
using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Commands;

public record CreateLostOtherPetCommand(Guid OwnerId, string ProfilePhoto, string Name, Gender Gender,
    DateTime DateOfBirth, bool IsSterilized,
    double Weight, ICollection<string> Photos, string Description, string FirstName,
    string PhoneNumber, bool IsVisible, DateTime DateOfDisappearance, double Longitude, double Latitude,string City,string Street,string ZipCode) : ICommand;