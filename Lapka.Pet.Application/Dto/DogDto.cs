using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Dto;

public class DogDto : PetDto
{
    public DogBreed Breed { get; set; }
    public DogColor Color { get; set; }
}