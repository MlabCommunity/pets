using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Api.Requests;

public record CreateOtherPetRequest(string Name,Guid ProfilePhotoId, Gender Gender,string Description,bool IsVisible, DateTime DateOfBirth, bool IsSterilized, double Weight,
    ICollection<Guid> Photos);