using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Repositories;

internal sealed class PetRepository : IPetRepository
{
    private readonly PetDbContext _context;
    private readonly DbSet<Core.Entities.Pet> _pets;

    public PetRepository(PetDbContext context)
    {
        _context = context;
        _pets = context.Pets;
    }

    public async Task AddPetAsync(Core.Entities.Pet pet)
    {
        await _pets.AddAsync(pet);
        await _context.SaveChangesAsync();
    }

}