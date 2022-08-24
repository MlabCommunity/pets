using AutoMapper;
using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Application.Mapper;

internal sealed class ShelterProfile : Profile
{
    public ShelterProfile()
    {
        CreateMap<Shelter, ShelterDto>();
        CreateMap<Volunteering, VolunteeringDto>();
        CreateMap<Volunteer, VolunteerDto>().ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email.Value));
        CreateMap<ShelterAdvertisement, ShelterAdvertisementDto>();
        CreateMap<ShelterAdvertisement, CurrentShelterAdvertisementDto>();
        CreateMap<Worker, WorkerDto>();
        CreateMap<Photo, PhotoDto>();
    }
}