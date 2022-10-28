using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Dto;

public class LostCatAdvertisementDto : LostPetAdvertisementDto
{
    public CatBreed Breed { get; set; }
}