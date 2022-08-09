using Lapka.Pet.Core.Domain;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class Shelter : AggregateRoot
{
    public ShelterId ShelterId { get; private set; }
    private Guid _logoId;
    private string _street;
    private string _city;
    private string _zipCode;
    private string _organizationName;
    private ICollection<Volunteering> _volunteerings;
    private ICollection<Volunteer> _volunteers;
    private string KRS;
    private string NIP;
    
    private Shelter()
    {
    }
    
    
    
}