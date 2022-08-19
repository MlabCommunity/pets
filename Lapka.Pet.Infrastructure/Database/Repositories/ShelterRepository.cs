using Lapka.Pet.Core.DomainThings;
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
    private readonly IAppDbContext _context;

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

    public async Task<Shelter> FindByIdAsync(AggregateId Id)
        => await _shelters.Include(x => x.Advertisements).Include(x => x.Volunteers).Include(x => x.Volunteering)
            .Include(x => x.Workers)
            .FirstOrDefaultAsync(x => x.Id == Id);

    public async Task<Shelter> FindByIdOrWorkerIdAsync(Guid principalId)
    => await _shelters.Include(x => x.Advertisements).Include(x => x.Volunteers).Include(x => x.Volunteering)
        .Include(x => x.Workers).FirstOrDefaultAsync(x => x.Workers.Contains(principalId) || x.Id==principalId);

    
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