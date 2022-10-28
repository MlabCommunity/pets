using Convey.CQRS.Events;
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
    private readonly AppDbContext _context;

    public UserUpdatedEventHandler(AppDbContext context, IShelterRepository shelterRepository)
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

                if (shelter is not null)
                {
                    shelter.Update(string.IsNullOrWhiteSpace(@event.Email) ? shelter.Email : @event.Email,
                        string.IsNullOrWhiteSpace(@event.FirstName) ? shelter.FirstName : @event.FirstName,
                        string.IsNullOrWhiteSpace(@event.LastName)
                            ? shelter.LastName
                            : @event
                                .LastName, //TODO imo eventy nie powinny przesyłać nulli jeżeli dana wartość sie nie zmieniła
                        Guid.Empty.ToString() == @event.ProfilePicture
                            ? null //TODO : imo tak nie powinno być, ale tak przychodzi 
                            : @event.ProfilePicture);
                    _shelters.Update(shelter);
                    await _context.SaveChangesAsync();
                }
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
                    _workers.Update(worker);
                    await _context.SaveChangesAsync();
                }
            }
                break;
        }
    }
}