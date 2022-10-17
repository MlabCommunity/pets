using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Core.ValueObjects;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Repositories;

internal sealed class PetRepository : IPetRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<Core.Entities.Pet> _pets;

    public PetRepository(AppDbContext context)
    {
        _context = context;
        _pets = context.Pets;
    }

    public async Task AddPetAsync(Core.Entities.Pet pet)
    {
        await _pets.AddAsync(pet);
        await _context.SaveChangesAsync();
    }

    public Task<Core.Entities.Pet> FindByIdAsync(PetId id)
        => _pets
            .Include(x => x.Visits)
            .ThenInclude(x => x.VisitTypes)
            .Include(x => x.Likes)
            .Include(x => x.Photos)
            .FirstOrDefaultAsync(s => s.Id == id);

    public Task<List<Core.Entities.Pet>> FindByOwnerId(OwnerId ownerId)
        => _pets
            .Include(x => x.Visits)
            .ThenInclude(x => x.VisitTypes)
            .Include(x => x.Likes)
            .Include(x => x.Photos)
            .Where(x=>x.OwnerId==ownerId)
            .ToListAsync();

    public async Task UpdateAsync(Core.Entities.Pet pet)
    {
        _pets.Update(pet);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Core.Entities.Pet pet)
    {
        _pets.Remove(pet);
        await _context.SaveChangesAsync();
    }
}