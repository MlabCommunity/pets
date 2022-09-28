using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Api.Requests;

public record CreateShelterCatRequest(string Name, string ProfilePhoto, Gender Gender, string Description,
    bool IsVisible, double Age, bool IsSterilized, double Weight,
    CatColor CatColor, CatBreed CatBreed, ICollection<string> Photos);