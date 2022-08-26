namespace Lapka.Pet.Core.ValueObjects;

public record Photo
{
    public PhotoId PhotoId { get; }

    private Photo()
    {
    }

    public Photo(Guid photoId)
    {
        PhotoId = photoId;
    }
}