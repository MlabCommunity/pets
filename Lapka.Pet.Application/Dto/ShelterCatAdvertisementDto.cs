using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Dto;

public class ShelterCatAdvertisementDto : ShelterPetAdvertisementDto
{
    public CatBreed CatBreed { get; set; }
    public CatColor CatColor { get; set; }
}