using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

string save = "";

PeopleContainer boite = new PeopleContainer(SaisieListeConsole());

if (boite.people.Count() > 0)
{
    Console.WriteLine("Souhaitez-vous trier par noms ou prenoms?\t(p pour prenoms)\t(n pour noms)");
    if (Console.ReadLine() == "p")
    {
        boite.people.Sort(new TriParPrenom());
    }
    else
    {
        boite.people.Sort(new TriParNom());
    }
}

Console.WriteLine("Sauvegarder la liste de personnes ? \t (o pour oui)");
save = Console.ReadLine();

if (save == "o")
{
    JsonSerialize(boite.people);
}



foreach (Person e in boite.people)
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

static void JsonSerialize(List<Person> _liste)
{
    string jsonString = JsonConvert.SerializeObject(_liste);
    string fileName = "save.json";

    File.WriteAllText(fileName, jsonString);
    Console.WriteLine(File.ReadAllText("save.json"));
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

 

    //public int CompareTo(object? obj)
    //{
    //    obj = (Person)obj;
    //    return firstName.CompareTo(obj.firstName);
    //}
}
public class TriParNom : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        return x.lastName.CompareTo(y.lastName);
    }
}
public class TriParPrenom : IComparer<Person>
{
    public int Compare(Person? x, Person? y)
    {
        return x.firstName.CompareTo(y.firstName);
    }
}

public class PeopleContainer  //Conteneur d'une liste personne qui permet aussi de les trier
{
    public List<Person> people;
    public PeopleContainer(){
        this.people = new List<Person>();
    }
    public PeopleContainer(List<Person> _people)
    {
        this.people = _people;
        this.people.Sort(new TriParNom());
    }

    //public List<Person> SortByLastName()
    //{


    //   return this.people.OrderBy(retour => retour.lastName).ToList();
    //}

    //public List<Person> SortByFirstName()
    //{
     
      
    //   return this.people.OrderBy(retour => retour.firstName).ToList();
    //}

}

interface IPersonContainer //Interface pour le PeopleContainer
{
    List<Person> SortByLastName();
    List<Person> SortByFirstName();
}


