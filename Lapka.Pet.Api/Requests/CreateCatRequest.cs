using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Api.Requests;

public record CreatePetRequest(string Name, Gender Gender, DateTime DateOfBirth, bool IsSterilized, double Weight,
    CatColor CatColor, CatBreed CatBreed);