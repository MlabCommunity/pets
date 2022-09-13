namespace Lapka.Pet.Application.Exceptions;

internal class EmailAlreadyTakenException : ProjectException
{
    internal EmailAlreadyTakenException() : base("Email is already taken", 400)
    {
    }
}