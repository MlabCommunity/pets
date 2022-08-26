using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Dto;

public class LostDogAdvertisementDetailsDto : LostPetAdvertisementDetailsDto
{
    public DogBreed DogBreed { get; set; }
    public DogColor DogColor { get; set; }
}