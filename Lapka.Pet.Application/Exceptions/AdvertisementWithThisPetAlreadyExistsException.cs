namespace Lapka.Pet.Application.Exceptions;

public class AdvertisementWithThisPetAlreadyExistsException : ProjectException
{
    public AdvertisementWithThisPetAlreadyExistsException() : base("Advertisement with this pet already exists")
    {
    }
}