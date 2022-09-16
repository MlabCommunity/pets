using Lapka.Pet.Core.Consts;

namespace Lapka.Pet.Application.Dto;

public class ShelterCatDto : ShelterPetDto
{
    public CatColor Color { get; set; }
}