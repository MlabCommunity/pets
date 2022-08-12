using AutoMapper;

namespace Lapka.Pet.Application.Dto;

public class PetProfile : Profile
{
    public PetProfile()
    {
        CreateMap<Core.Entities.Pet, PetDto>();
    }
}