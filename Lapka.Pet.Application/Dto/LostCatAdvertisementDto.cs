using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Dto;

public class LostCatAdvertisementDto : LostPetAdvertisementDto
{
    public CatColor CatColor { get; set; }
    public CatBreed CatBreed { get; set; }
}