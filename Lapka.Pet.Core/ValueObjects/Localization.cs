namespace Lapka.Pet.Core.ValueObjects;

public record Localization
{
    public Longitude Longitude { get; }
    public Latitude Latitude { get; }
    public Guid Fk { get; }

    protected Localization()
    {
    }

    public Localization(Longitude longitude, Latitude latitude, Guid fk)
    {
        Fk = fk;
        Longitude = longitude;
        Latitude = latitude;
    }
}