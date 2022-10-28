using Lapka.Pet.Application.Dto;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Infrastructure.Mapper;

internal static class VolunteeringMapper
{
    public static VolunteeringDto AsDto(this Volunteering volunteering)
        => new()
        {
            DonationDescription = volunteering.DonationDescription,
            DailyHelpDescription = volunteering.DailyHelpDescription,
            IsDonationActive = volunteering.IsDonationActive,
            IsDailyHelpActive = volunteering.IsDailyHelpActive,
            IsTakingDogsOutActive = volunteering.IsTakingDogsOutActive,
            BankAccountNumber = volunteering.BankAccountNumber,
            TakingDogsOutDescription = volunteering.TakingDogsOutDescription
        };
}