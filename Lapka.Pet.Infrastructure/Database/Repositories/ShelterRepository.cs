using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Core.ValueObjects;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Lapka.Pet.Infrastructure.Database.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Repositories;

internal sealed class ShelterRepository : IShelterRepository
{
    private readonly DbSet<Shelter> _shelters;
    private readonly PetDbContext _context;
    private readonly DbSet<WorkerId> _workers;

    public ShelterRepository(PetDbContext context)
    {
        _context = context;
        _shelters = context.Shelters;
        _workers = context.Workers;
    }

    public async Task AddAsync(Shelter shelter)
    {
        await _shelters.AddAsync(shelter);
        await _context.SaveChangesAsync();
    }

    public Task<Shelter> FindByUserIdAsync(Guid userId)
        => _shelters.FirstOrDefaultAsync(x => x.UserId == userId);

    public async Task<Shelter> FindByUserIdOrWorkerIdAsync(Guid principalId)
    {
        var worker = await _workers.FirstOrDefaultAsync(x => x.Value == principalId);
        if (worker is null)
        {
            return await FindByUserIdAsync(principalId);
        }

        return await FindByUserIdAsync(worker.Shelter.UserId);
    }


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