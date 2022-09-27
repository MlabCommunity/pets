using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Dto;

public class LikedShelterPetsDto
{
    public string Name { get; set; }
    public PetType Type { get; set; }
    public string ProfilePhoto { get; set; }
    public int Count { get; set; }
}