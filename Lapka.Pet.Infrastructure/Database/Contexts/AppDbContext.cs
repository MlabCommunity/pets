using Lapka.Pet.Core.Entities;
using Lapka.Pet.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Contexts;

internal class AppDbContext : DbContext
{
    public DbSet<Shelter> Shelters { get; set; }
    public DbSet<Worker> Workers { get; set; }
    public DbSet<Archive> Archives { get; set; }
    public DbSet<Core.Entities.Pet> Pets { get; set; }
    public DbSet<Cat> Cats { get; set; }
    public DbSet<Dog> Dogs { get; set; }
    public DbSet<Other> Others { get; set; }
    public DbSet<Volunteering> Volunteerings { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Volunteer> Volunteers { get; set; }
    public DbSet<ShelterPet> ShelterPets { get; set; }
    public DbSet<LostPet> LostPets { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<Visit> Visits { get; set; }
    public DbSet<VisitType> VisitTypes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("pets");

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}