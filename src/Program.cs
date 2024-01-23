Person myPerson = SaisieConsole();

Console.WriteLine(myPerson.lastName + " " + myPerson.firstName);

PeopleContainer boite = new();

boite.people.Add(myPerson);
boite.people.Add(new Person("Lincoln", "Abraham"));
boite.people.Add(new Person("Prime", "Optimus"));
boite.people.Add(new Person("Zord", "Mega"));


static Person SaisieConsole()
{
    string firstName;
    string lastName;

    Console.WriteLine("Saisissez le prénom: ");
    firstName = Console.ReadLine();
    Console.WriteLine("Saisissez le nom: ");
    lastName = Console.ReadLine();

    return new Person(lastName, firstName);
}

public class Person
{
    public string lastName;
    public string firstName;
    public Person(string _lastName, string _firstName)
    {
        this.lastName = _lastName;
        this.firstName = _firstName;
    }
}

public class PeopleContainer : IPersonContainer 
{
    public List<Person> people;
    public PeopleContainer(){
        this.people = new List<Person>;
    }


    public List<Person> SortByLastName(){
        return this.people.OrderBy(retour => retour.lastName).ToList();
    }

    public List<Person> SortByFirstName(){
        return this.people.OrderBy(retour => retour.firstName).ToList();
    }

}

interface IPersonContainer
{
    List<Person> SortByLastName();
    List<Person> SortByFirstName();
}
