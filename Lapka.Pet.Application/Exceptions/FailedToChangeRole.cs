namespace Lapka.Pet.Application.Exceptions;

public class FailedToChangeRole : ProjectException
{
    public FailedToChangeRole(string message, Exception inner = null) : base("Failed to change role:" + message, 500)
    {
    }
}