// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Person personTest = new Person("Test", "Retest");

Console.WriteLine(personTest.lastName + " " + personTest.firstName);

public class Person{
    public string lastName;
    public string firstName;
    public Person(string _lastName, string _firstName){
        this.lastName = _lastName;
        this.firstName = _firstName;
    }
    
}