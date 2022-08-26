namespace Lapka.Pet.Application.Exceptions;

public class UserNotFoundException : ProjectException
{
    public UserNotFoundException() : base("User not found.")
    {
    }
}