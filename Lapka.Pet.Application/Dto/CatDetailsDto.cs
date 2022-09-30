using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Dto;

public class CatDetailsDto : PetDetailsDto
{
    public CatBreed Breed { get; set; }
    public CatColor Color { get; set; }
}