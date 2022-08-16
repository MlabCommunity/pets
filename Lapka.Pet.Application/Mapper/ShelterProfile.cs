using AutoMapper;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Infrastructure.Mapper;

internal sealed class ShelterProfile : Profile
{
    public ShelterProfile()
    {
        CreateMap<Shelter, ShelterDto>();
    }
}