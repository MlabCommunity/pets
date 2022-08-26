using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Contexts;

internal class AppDbContext : DbContext, IAppDbContext
{
    public DbSet<Shelter> Shelters { get; set; }
    public DbSet<Worker> Workers { get; set; }
    public DbSet<Core.Entities.Pet> Pets { get; set; }
    public DbSet<Cat> Cats { get; set; }
    public DbSet<Dog> Dogs { get; set; }
    public DbSet<Volunteering> Volunteerings { get; set; }
    public DbSet<Volunteer> Volunteers { get; set; }
    public DbSet<ShelterAdvertisement> ShelterAdvertisements { get; set; }
    public DbSet<LostPetAdvertisement> LostPetAdvertisements { get; set; }
    public DbSet<Advertisement> Advertisements { get; set; }
    public DbSet<Photo> Photos { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("pets");

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}