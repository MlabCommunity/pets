using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Application.Dto;

public class ShelterAdvertisementDto 
{
    public Guid Id { get; set; }
    public bool IsReserved { get; set; }
    public string Description { get; set; }
    public string OrganizationName { get; set; }
    public string Localization { get; set; }
    public PetDto Pet { get; set; }


}