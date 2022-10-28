namespace Lapka.Pet.Application.Exceptions;

internal class AdvertisementNotFoundException : ProjectException
{
    internal AdvertisementNotFoundException() : base("Advertisement not found", 404)
    {
    }
}