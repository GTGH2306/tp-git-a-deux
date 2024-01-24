PeopleContainer boite = new(SaisieListeConsole());

foreach (Person e in boite.SortByFirstName())
{
    Console.WriteLine(e.firstName + " " + e.lastName);
}


static List<Person> SaisieListeConsole() //Retourne une liste de personne saisie par utilisateur en console
{
    List<Person> retour = new List<Person>();
    string saisie;
    int minPeople;

    minPeople = 3;
    saisie = "OUI, SELON TRISTAN";

    do
    {
        retour.Add(SaisieConsole(retour));
        if (retour.Count() >= minPeople)
        {
            Console.WriteLine("Continuer?\t(n pour Non)");
            saisie = Console.ReadLine().ToLower();
        }
    } while (saisie != "n");

    return retour;
}

static Person SaisieConsole(List<Person> _retour) //Retourne une personne saisie par utilisateur en console
{
    string firstName;
    string lastName;
    Person retour;
    

    Console.WriteLine("Saisissez le prénom: ");
    firstName = Console.ReadLine();
    Console.WriteLine("Saisissez le nom: ");
    lastName = Console.ReadLine();
    if(DoublonController(_retour, firstName, lastName))
    {
        Console.WriteLine("Doublon détecté.");
        retour = SaisieConsole(_retour);
    }
    else
    {
        retour = new Person(firstName, lastName);
    }

    return retour;
}

static bool DoublonController(List<Person> _liste, string _firstName, string _lastName)
{
    bool doublon = false;
    /*
    foreach(Person e in _liste){
        Console.WriteLine(e.firstName + " " + e.lastName);
        Console.WriteLine(_firstName + " " + _lastName);
        if (e.firstName.Equals(_firstName) && e.lastName.Equals(_lastName)){
            Console.WriteLine("Doublon détecté");
            doublon = true;
        }
    }
    */
    if (_liste.FindAll(Person => Person.firstName.Equals(_firstName) && Person.lastName.Equals(_lastName)).Count() > 0)
    {
        doublon = true;
    }
    return doublon;
}

public class Person //Objet personne ayant un prénom et un nom
{
    public string lastName;
    public string firstName;
    public Person(string _firstName, string _lastName)
    {
        this.lastName = _lastName;
        this.firstName = _firstName;
    }
}

public class PeopleContainer: IPersonContainer  //Conteneur d'une liste personne qui permet aussi de les trier
{
    public List<Person> people;
    public PeopleContainer(){
        this.people = new List<Person>();
    }
    public PeopleContainer(List<Person> _people)
    {
        this.people = _people;
    }

    public List<Person> SortByLastName(){

        
       return this.people.OrderBy(retour => retour.lastName).ToList();
    }

    public List<Person> SortByFirstName(){
        return this.people.OrderBy(retour => retour.firstName).ToList();
    }

}

interface IPersonContainer //Interface pour le PeopleContainer
{
    List<Person> SortByLastName();
    List<Person> SortByFirstName();
}
