// See https://aka.ms/new-console-template for more information
string firstName;
string lastName;

Console.WriteLine("Saisissez le prénom: ");
firstName = Console.ReadLine();
Console.WriteLine("Saisissez le nom: ");
lastName = Console.ReadLine();

Console.WriteLine(firstName + " " + lastName);

Person myPerson = new(lastName, firstName);

Console.WriteLine(myPerson.lastName + " " + myPerson.firstName);

List<Person> people = new List<Person>();

people.Add(new Person("Watson", "Bobby"));
people.Add(new Person("Lincoln", "Abraham"));
people.Add(new Person("Prime", "Optimus"));
people.Add(new Person("Zord", "Mega"));



public class Person{
    public string lastName;
    public string firstName;
    public Person(string _lastName, string _firstName){
        this.lastName = _lastName;
        this.firstName = _firstName;
    }
}

public class PeopleContainer : IPersonContainer 
{
    List<Person> people;

    public PeopleContainer(List<Person> _people){
        this.people = _people;
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