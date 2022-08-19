namespace Lapka.Pet.Core.Exceptions;

public class AdvertisementAlreadyExistsException : DomainException
{
    public AdvertisementAlreadyExistsException() : base("Advertisement with this pet already exists")
    {
    }
}