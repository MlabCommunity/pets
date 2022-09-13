using Convey.CQRS.Events;
using Lapka.Pet.Application.Exceptions;
using Lapka.Pet.Application.IntegrationEvents;
using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.Repositories;
using Lapka.Pet.Core.ValueObjects;
using Lapka.Pet.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.IntegrationEventHandlers;

internal sealed class UserUpdatedEventHandler : IEventHandler<UserUpdatedEvent>
{
    private readonly DbSet<Shelter> _shelters;
    private readonly DbSet<Worker> _workers;
    private readonly IAppDbContext _context;

    public UserUpdatedEventHandler(IAppDbContext context, IShelterRepository shelterRepository)
    {
        _shelters = context.Shelters;
        _context = context;
        _workers = context.Workers;
    }

    public async Task HandleAsync(UserUpdatedEvent @event,
        CancellationToken cancellationToken = new CancellationToken())
    {
        switch (@event.Role)
        {
            case "Shelter":
            {
                var shelter = await _shelters.FirstOrDefaultAsync(x => x.Id == @event.UserId);

                if (shelter is null)
                {
                    throw new ShelterNotFoundException();
                }

                shelter.Update(@event.Email, Guid.Parse(@event.ProfilePictureId));

                await _context.SaveChangesAsync();
            }
                break;
            case "Worker":
            {
                var worker = await _workers.FirstOrDefaultAsync(x => x.WorkerId == @event.UserId);

                if (worker is not null)
                {
                    worker = worker with
                    {
                        Email = @event.Email,
                        FirstName = @event.FirstName,
                        LastName = @event.LastName
                    };
                }

                await _context.SaveChangesAsync();
            }
                break;
        }
    }
}