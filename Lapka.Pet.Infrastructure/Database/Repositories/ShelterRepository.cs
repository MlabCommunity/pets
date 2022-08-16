using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Repositories;

internal sealed class ShelterRepository : IShelterRepository
{
    private readonly DbSet<Shelter> _shelters;
    private readonly PetDbContext _context;

    public ShelterRepository(PetDbContext context)
    {
        _context = context;
        _shelters = context.Shelters;
    }

    public async Task AddAsync(Shelter shelter)
    {
        await _shelters.AddAsync(shelter);
        await _context.SaveChangesAsync();
    }

    public Task<Shelter> FindByUserIdAsync(Guid userId)
        => _shelters.FirstOrDefaultAsync(x => x.UserId == userId);

    public async Task UpdateAsync(Shelter shelter)
    {
        _shelters.Update(shelter);
        await _context.SaveChangesAsync();
    }
}