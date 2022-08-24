using AutoMapper;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Application.Mapper;

internal sealed class PetProfile : Profile
{
    public PetProfile()
    {
        CreateMap<Core.Entities.Pet, PetDto>()
            .Include<Cat, CatDto>()
            .Include<Dog, DogDto>()
            .Include<Other, OtherDto>();
        CreateMap<Cat, CatDto>();
        CreateMap<Dog, DogDto>();
        CreateMap<Other, OtherDto>();
    }
}