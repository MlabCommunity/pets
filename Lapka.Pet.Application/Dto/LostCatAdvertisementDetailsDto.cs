using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Dto;

public class LostCatAdvertisementDetailsDto : LostPetAdvertisementDetailsDto
{
    public CatBreed Breed { get; set; }
    public CatColor Color { get; set; }
}