using Lapka.Pet.Core.Domain;

namespace Lapka.Pet.Core.ValueObjects;

public class Volunteering
{
    //Tutaj niestety dodałem Id bo nie mogłem zrobić teog jako
    //VO ponieważ dużo rzeczy tu będzie się edytowało. VO powinno być immutable a jednaka często będzie się zmieniało statusy. Z drugiej strony tożsamość tej encji jest zbędna
   
    // a może nie pchać tego w 1:1 tylko osobne tabele? przy edycji i pobieraniu główna tablea Shelters nie będzie pobierana czyli apka zyska na wydajności 
    public EntityId VolunteerId { get; private set; }
    private bool _isDonationActived;
    private string _bankAccountNumber;
    private string _donationDescription;
    private bool _isDailyHelpActived;
    private string _dailyHelpDescription;
    private bool _isTakingDogsOutActived;
    private string _takingDogsOutDescription;

    public Volunteering()
    {
        _isDonationActived = false;
        _isDailyHelpActived = false;
        _isTakingDogsOutActived = false;
        // opisy jako empty/null?
    }
    
    //Metody edycji i statusów
}