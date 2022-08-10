using Microsoft.EntityFrameworkCore;

namespace Lapka.Pet.Infrastructure.Database.Contexts;

public class Context : DbContext, IContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    //Sets from Interface

    //On model creating
}