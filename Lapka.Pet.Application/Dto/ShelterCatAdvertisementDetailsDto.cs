using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Dto;

public class ShelterCatAdvertisementDetailsDto : ShelterPetAdvertisementDetailsDto
{
    public CatColor Color { get; set; }
    public CatBreed Breed { get; set; }

}