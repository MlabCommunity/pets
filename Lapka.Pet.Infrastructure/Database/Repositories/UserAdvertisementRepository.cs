using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Core.ValueObjects;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Repositories;

internal sealed class UserAdvertisementRepository : IUserAdvertisementRepository
{
    private readonly IAppDbContext _context;
    private readonly DbSet<UserAdvertisement> _advertisements;

    public UserAdvertisementRepository(AppDbContext context)
    {
        _context = context;
        _advertisements = context.UserAdvertisements;
    }

    public async Task AddAsync(UserAdvertisement advertisement)
    {
        await _advertisements.AddAsync(advertisement);
        await _context.SaveChangesAsync();
    }

    public async Task<UserAdvertisement> FindByPetIdAsync(PetId petId)
        => await _advertisements.FirstOrDefaultAsync(x => x.PetId == petId);

    public async Task<UserAdvertisement> FindByIdAsync(EntityId EntityId)
        => await _advertisements.FirstOrDefaultAsync(x => x.Id == EntityId);


    public async Task UpdateAsync(UserAdvertisement advertisement)
    {
        _advertisements.Update(advertisement);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(UserAdvertisement advertisement)
    {
        _advertisements.Remove(advertisement);
        await _context.SaveChangesAsync();
    }
}