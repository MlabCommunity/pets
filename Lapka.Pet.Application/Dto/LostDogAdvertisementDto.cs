using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Dto;

public class LostDogAdvertisementDto : LostPetAdvertisementDto
{
    public DogBreed Breed { get; set; }

}