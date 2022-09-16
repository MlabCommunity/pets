namespace Lapka.Pet.Core.ValueObjects;

public record Photo
{
    public PhotoId PhotoId { get; }

    private Photo()
    {
    }

    public Photo(PhotoId photoId)
    {
        PhotoId = photoId;
    }
}