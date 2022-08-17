using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;
using Lapka.Pet.Infrastructure.Database.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Contexts;

internal class PetDbContext : DbContext, IPetDbContext
{
    public DbSet<Shelter> Shelters { get; set; }
    public DbSet<PetId> ShelterPets { get; set; }
    public DbSet<WorkerId> Workers { get; set; }
    public DbSet<Core.Entities.Pet> Pets { get; set; }
    public DbSet<Cat> Cats { get; set; }
    public DbSet<Dog> Dogs { get; set; }

    public PetDbContext(DbContextOptions<PetDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("pets");

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}