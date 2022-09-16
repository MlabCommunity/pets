using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Dto;

public class ShelterDogDto : ShelterPetDto
{
    public DogColor Color { get; set; }
}