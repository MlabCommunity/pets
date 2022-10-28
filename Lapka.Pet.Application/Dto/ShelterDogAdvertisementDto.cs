using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Dto;

public class ShelterDogAdvertisementDto : ShelterPetAdvertisementDto
{
    public DogBreed Breed { get; set; }
}