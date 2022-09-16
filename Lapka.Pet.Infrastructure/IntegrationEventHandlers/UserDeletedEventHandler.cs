using Convey.CQRS.Events;
using Lapka.Pet.Application.IntegrationEvents;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Core.ValueObjects;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.IntegrationEventHandlers;

internal sealed class UserDeletedEventHandler : IEventHandler<UserDeletedEvent>
{
    private readonly DbSet<Shelter> _shelters;
    private readonly DbSet<Worker> _workers;
    private readonly AppDbContext _context;
    private readonly DbSet<Core.Entities.Pet> _pets;
    private readonly DbSet<Volunteer> _volunteers;

    public UserDeletedEventHandler(AppDbContext context)
    {
        _context = context;
        _pets = context.Pets;
        _shelters = context.Shelters;
        _volunteers = context.Volunteers;
        _workers = context.Workers;
    }

    public async Task HandleAsync(UserDeletedEvent @event,
        CancellationToken cancellationToken = new CancellationToken())
    {
        switch (@event.Role)
        {
            case "Shelter":
            {
                var shelter = await _shelters.FirstOrDefaultAsync(x => x.Id == @event.UserId);

                if (shelter is not null)
                {
                    _shelters.Remove(shelter);
                }
            } break;
            case "Worker" or "User":
            {
                var worker = await _workers.FirstOrDefaultAsync(x => x.WorkerId == @event.UserId);

                if (worker is not null)
                {
                    _workers.Remove(worker);
                }

                var volunteer = await _volunteers.Where(x => x.UserId == @event.UserId).ToListAsync();


                _volunteers.RemoveRange(volunteer);
            } break;
        }

        var pets = await _pets.Where(x => x.OwnerId == @event.UserId).ToListAsync();
        _pets.RemoveRange(pets);
        await _context.SaveChangesAsync();
    }
}