namespace Lapka.Pet.Application.Dto;

public class ShelterDto
{
    public Guid Id { get; set; }
    public string OrganizationName { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ProfilePhoto { get; set; }
    public string PhoneNumber { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public double? Distance { get; set; }
}