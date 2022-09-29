using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Api.Requests;

public record CreateOtherPetRequest(string Name,string ProfilePhoto, Gender Gender, DateTime DateOfBirth, bool IsSterilized, double Weight,
    ICollection<string> Photos);