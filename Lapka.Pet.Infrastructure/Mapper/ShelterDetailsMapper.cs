using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Infrastructure.Mapper;

public static class ShelterDetailsMapper
{
    public static ShelterDetailsDto AsDetailsDto(this Shelter shelter)
        => new()
        {
            Id = shelter.Id,
            OrganizationName = shelter.OrganizationName,
            ProfilePhoto = shelter.ProfilePhoto,
            FirstName = shelter.FirstName,
            BankAccount = shelter.Volunteering.BankAccountNumber,
            Email = shelter.Email,
            Nip = shelter.Nip,
            Krs = shelter.Krs,
            LastName = shelter.LastName,
            PhoneNumber = shelter.PhoneNumber,
            City = shelter.City,
            Street = shelter.Street,
            ZipCode = shelter.ZipCode
        };
}