using Lapka.Pet.Core.DomainThings;
using Lapka.Pet.Core.ValueObjects;

namespace Lapka.Pet.Core.Entities;

public abstract class Advertisement
{
    public EntityId Id { get; private set; }
    public string Description { get; private set; }
    public ICollection<PhotoId> Photos = new List<PhotoId>();
    public bool IsVisible { get; private set; }

    protected Advertisement()
    {
    }
    
    protected Advertisement(string description, bool isVisible)
    {
        Id = Guid.NewGuid();
        Description = description;
        IsVisible = isVisible;
    }

    public void Publish()
    {
        IsVisible = true;
    }

    public void Hide()
    {
        IsVisible = false;
    }
    
    public void Update(string description)
    {
        Description = description;
    }
}