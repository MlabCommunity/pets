using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Core.ValueObjects;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Repositories;

internal sealed class PetRepository : IPetRepository
{
    private readonly IAppDbContext _context;
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

    public Task<Core.Entities.Pet> FindByIdAsync(AggregateId id)
        => _pets
            .Include(x => x.Visits)
            .ThenInclude(x => x.VisitTypes)
            .Include(x => x.Photos)
            .FirstOrDefaultAsync(s => s.Id == id);


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

    public async Task RemoveByIdAsync(AggregateId petId)
    {
        var pet = await FindByIdAsync(petId);
        await RemoveAsync(pet);
    }

    public async Task RemoveByOwnerIdAsync(OwnerId ownerId)
    {
        var pets = await _pets.Where(x => x.OwnerId == ownerId).ToListAsync();
        _pets.RemoveRange(pets);
        await _context.SaveChangesAsync();
    }
}