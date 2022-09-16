using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Dto;

public class ShelterDogAdvertisementDetailsDto : ShelterPetAdvertisementDetailsDto
{
    public DogColor Color { get; set; }
    public DogBreed Breed { get; set; }

}