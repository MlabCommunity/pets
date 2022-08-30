using Lapka.Pet.Core.DomainThings;

namespace Lapka.Pet.Core.ValueObjects;

public class Visit
{
    public EntityId VisitId { get; set; }
    public bool HasTookPlace { get; set; }
    public DateTime DateOfVisit { get;set; }
    public string Description { get;set;}
    public ICollection<VisitType> VisitTypes = new List<VisitType>();
    public Weight WeightOnVisit { get; }

    private Visit()
    {
    }

    public Visit(bool hasTookPlace, DateTime dateOfVisit, string description, ICollection<Consts.CareType> visitTypes, Weight weightOnVisit)
    {
        HasTookPlace = hasTookPlace;
        DateOfVisit = dateOfVisit;
        Description = description;
        AddTypes(visitTypes);
        WeightOnVisit = weightOnVisit;
    }

    public void AddTypes(ICollection<Consts.CareType> visitTypes)
    {
        foreach (var type in visitTypes)
        {
            VisitTypes.Add(new VisitType(type));
        }
    }
}