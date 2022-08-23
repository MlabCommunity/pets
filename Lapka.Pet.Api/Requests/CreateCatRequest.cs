using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Api.Requests;

public record CreateCatRequest(string Name, Gender Gender, DateTime DateOfBirth, bool IsSterilized, double Weight,
    CatColor CatColor, CatBreed CatBreed);