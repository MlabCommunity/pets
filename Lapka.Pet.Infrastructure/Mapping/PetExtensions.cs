using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Infrastructure.Mapping;

internal static class PetExtensions
{
    public static CatDto AsDto(this Cat cat)
        => new()
        {
            Id = cat.Id,
            Name = cat.Name,
            DateOfBirth = cat.DateOfBirth,
            Gender = cat.Gender,
            IsSterilized = cat.IsSterilized,
            Type = cat.Type,
            Weight = cat.Weight
        };
    
    public static OtherDto AsDto(this Other other)
        => new()
        {
            Id = other.Id,
            Name = other.Name,
            DateOfBirth = other.DateOfBirth,
            Gender = other.Gender,
            IsSterilized = other.IsSterilized,
            Type = other.Type,
            Weight = other.Weight,
        };
    
    public static DogDto AsDto(this Dog dog)
        => new()
        {
            Id = dog.Id,
            Name = dog.Name,
            DateOfBirth = dog.DateOfBirth,
            Gender = dog.Gender,
            IsSterilized = dog.IsSterilized,
            Type = dog.Type,
            Weight = dog.Weight,
            Breed = dog.Breed,
            Color = dog.Color
        };
}