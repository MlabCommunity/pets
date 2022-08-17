namespace Lapka.Pet.Application.Dto;

public class VolunteeringDto
{
    public bool IsDonationActive { get; set; }
    public string BankAccountNumber { get;  set;}
    public string DonationDescription { get; set; }
    public bool IsDailyHelpActive { get;  set;}
    public string DailyHelpDescription { get; set; }
    public bool IsTakingDogsOutActive { get;  set;}
    public string TakingDogsOutDescription { get; set; }
}