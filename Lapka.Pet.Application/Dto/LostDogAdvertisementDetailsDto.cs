using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Dto;

public class LostDogAdvertisementDetailsDto : LostPetAdvertisementDetailsDto
{
    public DogBreed Breed { get; set; }
    public DogColor Color { get; set; }
}