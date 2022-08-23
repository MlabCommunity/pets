using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Core.ValueObjects;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Repositories;

internal sealed class LostPetAdvertisementRepository : ILostPetAdvertisementRepository
{
    private readonly IAppDbContext _context;
    private readonly DbSet<LostPetAdvertisement> _advertisements;

    public LostPetAdvertisementRepository(AppDbContext context)
    {
        _context = context;
        _advertisements = context.LostPetAdvertisements;
    }

    public async Task AddAsync(LostPetAdvertisement advertisement)
    {
        await _advertisements.AddAsync(advertisement);
        await _context.SaveChangesAsync();
    }

    public async Task<LostPetAdvertisement> FindByPetIdAsync(PetId petId)
        => await _advertisements.FirstOrDefaultAsync(x => x.PetId == petId);

    public async Task<LostPetAdvertisement> FindByIdAsync(EntityId EntityId)
        => await _advertisements.FirstOrDefaultAsync(x => x.Id == EntityId);

    public async Task<LostPetAdvertisement> FindByUserIdAsync(UserId UserId)
           => await _advertisements.FirstOrDefaultAsync(x => x.UserId == UserId);


    public async Task UpdateAsync(LostPetAdvertisement advertisement)
    {
        _advertisements.Update(advertisement);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(LostPetAdvertisement advertisement)
    {
        _advertisements.Remove(advertisement);
        await _context.SaveChangesAsync();
    }
}