namespace Lapka.Pet.Core.ValueObjects;

public record Photo
{
    public PhotoLink PhotoLink { get; }

    private Photo()
    {
    }

    public Photo(PhotoLink photoLink)
    {
        PhotoLink = photoLink;
    }
}