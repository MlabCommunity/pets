using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Core.ValueObjects;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Repositories;

internal sealed class LostPetRepository : ILostPetRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<LostPet> _advertisements;

    public LostPetRepository(AppDbContext context)
    {
        _context = context;
        _advertisements = context.LostPets;
    }

    public async Task AddAsync(LostPet advertisement)
    {
        await _advertisements.AddAsync(advertisement);
        await _context.SaveChangesAsync();
    }

    public async Task<LostPet> FindByPetIdAsync(PetId petId)
        => await _advertisements.FirstOrDefaultAsync(x => x.Id == petId);
    
    public async Task UpdateAsync(LostPet advertisement)
    {
        _advertisements.Update(advertisement);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(LostPet advertisement)
    {
        _advertisements.Remove(advertisement);
        await _context.SaveChangesAsync();
    }
}