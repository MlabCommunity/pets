namespace Lapka.Pet.Infrastructure.Database.Contexts;

public interface IContext
{
    // DbSets with all the entities
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}