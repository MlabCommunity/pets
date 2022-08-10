using Lapka.Pet.Core.Entities;

namespace Lapka.Pet.Core.ValueObjects;

public class Volunteer
{
    private ICollection<Shelter> _shelters;
    private UserId _userId;
}