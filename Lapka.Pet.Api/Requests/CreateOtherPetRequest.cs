using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Api.Requests;

public record CreateOtherPetRequest(string Name, Gender Gender, DateTime DateOfBirth, bool IsSterilized, double Weight,
    ICollection<Guid> Photos);