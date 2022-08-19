namespace Lapka.Pet.Core.Exceptions;

public class AdvertisementNotFoundException : DomainException
{
    public AdvertisementNotFoundException() : base("Advertisement not found")
    {
    }

}