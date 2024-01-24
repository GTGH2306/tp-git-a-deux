
PeopleContainer boite = new(SaisieListeConsole());

foreach (Person e in boite.SortByFirstName())
{
    Console.WriteLine(e.firstName);
}


static List<Person> SaisieListeConsole() //Retourne une liste de personne saisie par utilisateur en console
{
    List<Person> retour = new List<Person>();
    string saisie;

    do
    {
        retour.Add(SaisieConsole());
        Console.WriteLine("Continuer?\t(n pour Non)");
        saisie = Console.ReadLine().ToLower();
    } while (saisie == "n");

    return retour;
}

static Person SaisieConsole() //Retourne une personne saisie par utilisateur en console
{
    string firstName;
    string lastName;

    Console.WriteLine("Saisissez le prénom: ");
    firstName = Console.ReadLine();
    Console.WriteLine("Saisissez le nom: ");
    lastName = Console.ReadLine();

    return new Person(lastName, firstName);
}

public class Person //Objet personne ayant un prénom et un nom
{
    public string lastName;
    public string firstName;
    public Person(string _lastName, string _firstName)
    {
        this.lastName = _lastName;
        this.firstName = _firstName;
    }
}

public class PeopleContainer : IPersonContainer  //Conteneur d'une liste personne qui permet aussi de les trier
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
