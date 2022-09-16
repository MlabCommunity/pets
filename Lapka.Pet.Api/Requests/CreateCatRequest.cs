using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Api.Requests;

public record CreateCatRequest(string Name,Guid ProfilePhotoId, Gender Gender,string Description,bool IsVisible, DateTime DateOfBirth, bool IsSterilized, double Weight,
    CatColor CatColor, CatBreed CatBreed, ICollection<Guid> Photos);