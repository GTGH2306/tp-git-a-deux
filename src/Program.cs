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

public class Person{
    public string lastName;
    public string firstName;
    public Person(string _lastName, string _firstName){
        this.lastName = _lastName;
        this.firstName = _firstName;
    }
    
}