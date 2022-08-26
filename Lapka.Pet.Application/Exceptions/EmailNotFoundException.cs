namespace Lapka.Pet.Application.Exceptions;

public class EmailNotFoundException : ProjectException
{
    public EmailNotFoundException() : base("Email not found.")
    {
    }
}