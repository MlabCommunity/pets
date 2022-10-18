using Lapka.Pet.Core.Consts;
using Lapka.Pet.Core.Kernel.Types;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public class Visit
{
    public EntityId VisitId { get; private set; }
    public bool? HasTookPlace { get; private set; }
    public DateTime DateOfVisit { get; private set; }
    public string Description { get; private set; }
    public HashSet<VisitType> VisitTypes = new HashSet<VisitType>();
    public WeightOnVisit? WeightOnVisit { get; private set; }
    public Pet Pet { get; }
    public PetId PetId { get; }

    private Visit()
    {
    }

    public Visit(bool? hasTookPlace, DateTime dateOfVisit, string description, HashSet<CareType> visitTypes,
        WeightOnVisit? weightOnVisit, Pet pet)
    {
        VisitId = Guid.NewGuid();
        HasTookPlace = hasTookPlace;
        DateOfVisit = dateOfVisit;
        Description = description;
        SetTypes(visitTypes);
        WeightOnVisit = weightOnVisit;
        Pet = pet;
        PetId = pet.Id;
    }

    public void SetTypes(HashSet<CareType> visitTypes)
    {
        VisitTypes.Clear();
        foreach (var type in visitTypes)
        {
            VisitTypes.Add(new VisitType(type, this));
        }
    }

    public void Update(bool hasTookPlace, DateTime dateOfVisit, string description, HashSet<CareType> visitTypes,
        double weightOnVisit)
    {
        HasTookPlace = hasTookPlace;
        DateOfVisit = dateOfVisit;
        Description = description;
        WeightOnVisit = weightOnVisit;
        SetTypes(visitTypes);
    }
}