using System.Data;
using Lapka.Pet.Core.Domain;

namespace Lapka.Pet.Core.ValueObjects;

public class Volunteering
{
    //Tutaj niestety dodałem Id bo nie mogłem zrobić teog jako
    //VO ponieważ dużo rzeczy tu będzie się edytowało. VO powinno być immutable a jednaka często będzie się zmieniało statusy. Z drugiej strony tożsamość tej encji jest zbędna

    // a może nie pchać tego w 1:1 tylko osobne tabele? przy edycji i pobieraniu główna tablea Shelters nie będzie pobierana czyli apka zyska na wydajności 
    public EntityId VolunteeringId { get; private set; }
    private bool _isDonationActive;
    private string _bankAccountNumber;
    private string _donationDescription;
    private bool _isDailyHelpActive;
    private string _dailyHelpDescription;
    private bool _isTakingDogsOutActive;
    private string _takingDogsOutDescription;

    public Volunteering()
    {
        VolunteeringId = Guid.NewGuid();
        _isDonationActive = false;
        _isDailyHelpActive = false;
        _isTakingDogsOutActive = false;
    }
    
    //Metody edycji i statusów

    public void Update(bool isDonationActive, string bankAccountNumber, string donationDescription,
        bool isDailyHelpActive,
        string dailyHelpDescription, bool isTakingDogsOutActive, string takingDogsOutDescription)
    {
        _isDonationActive = isDonationActive;
        _bankAccountNumber = bankAccountNumber;
        _donationDescription = donationDescription;
        _isDailyHelpActive = isDailyHelpActive;
        _dailyHelpDescription = dailyHelpDescription;
        _isTakingDogsOutActive = isTakingDogsOutActive;
        _takingDogsOutDescription = takingDogsOutDescription;
    }
}