using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Core.ValueObjects;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Repositories;

internal sealed class ShelterAdvertisementRepository : IShelterAdvertisementRepository
{
    private readonly IAppDbContext _context;
    private readonly DbSet<ShelterAdvertisement> _advertisements;

    public ShelterAdvertisementRepository(AppDbContext context)
    {
        _context = context;
        _advertisements = context.ShelterAdvertisements;
    }

    public async Task<ShelterAdvertisement> FindByShelterIdAsync(ShelterId id)
        => await _advertisements.FirstOrDefaultAsync(x => x.ShelterId == id.Value);

    public async Task UpdateAsync(ShelterAdvertisement shelterAdvertisement)
    {
        _advertisements.Update(shelterAdvertisement);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(ShelterAdvertisement shelterAdvertisement)
    {
        _advertisements.Remove(shelterAdvertisement);
        await _context.SaveChangesAsync();
    }
}