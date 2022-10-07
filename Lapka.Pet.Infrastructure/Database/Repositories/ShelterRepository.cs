using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Core.ValueObjects;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Repositories;

internal sealed class ShelterRepository : IShelterRepository
{
    private readonly DbSet<Shelter> _shelters;
    private readonly AppDbContext _context;

    public ShelterRepository(AppDbContext context)
    {
        _context = context;
        _shelters = context.Shelters;
    }

    public async Task AddAsync(Shelter shelter)
    {
        await _shelters.AddAsync(shelter);
        await _context.SaveChangesAsync();
    }

    public async Task<Shelter> FindByIdAsync(ShelterId id)
        => await _shelters
            .Include(x => x.Localization)
            .Include(x => x.ShelterPets).ThenInclude(x => x.Photos)
            .Include(x => x.Volunteers)
            .Include(x => x.Volunteering)
            .Include(x => x.Workers)
            .Include(x => x.Archives)
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task UpdateAsync(Shelter shelter)
    {
        _shelters.Update(shelter);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Shelter shelter)
    {
        _shelters.Remove(shelter);
        await _context.SaveChangesAsync();
    }
}