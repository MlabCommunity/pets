using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Api.Requests;

public record CreateShelterOtherRequest(string Name, string ProfilePhoto, Gender Gender, string Description,
    bool IsVisible, double Age, bool IsSterilized, double Weight,
    ICollection<string> Photos);