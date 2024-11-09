/*
Zadanie 1 a.
Stwórz klasy:
• Person z polami: FirstName, LastName, wiek, konstruktorem inicjującym wszystkie pola oraz
metodą View.
• Book z polami: title, author (typu Person), data wydania oraz metodą View.
Utwórz różne obiekty stworzonych klas. Wykonaj metody View.
*/
class Person
{
    private string FirstName;
    private string LastName;
    private int wiek;
    public Person(string firstName, string lastName, int wiek)
    {
        FirstName = firstName;
        LastName = lastName;
        this.wiek = wiek;
    }
    public void View()
    {
        Console.WriteLine($"Name: {FirstName}, lastname: {LastName}, age: {wiek}");
    }
}
class Book
{
    private string title;
    private Person author;
    private int dataWydania;

    public Book(string title, Person author, int dataWydania)
    {
        this.title = title;
        this.author = author;
        this.dataWydania = dataWydania;
    }
    public void View()
    {
        Console.WriteLine($"Title: {title}, date: {dataWydania}");
        Console.Write("Author:");
        author.View();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person person1 = new Person("Big", "Man", 69);

        Book book1 = new Book("How to", person1, 1996);

        person1.View();
        book1.View();
       

    }
}

/*
Zadanie 1 b.
Stwórz klasę Reader, dziedziczącą z klasy Person. Dodatkowo klasa Reader powinna posiadać pole –
listę / tablicę obiektów typu Book - listę książek przeczytanych przez danego czytelnika oraz metodę
ViewBook - wypisujące tytuły książek, które czytelnik przeczytał.
Stwórz 3-5 książek, 2-4 czytelników, przypisz książki do tablic / list przeczytanych książek czytelników,
wykonaj metody ViewBook.
*/
class Reader : Person
{
    private string[] list;
    public Reader(string firstName, string lastName, int wiek) : base(firstName, lastName, wiek)
    {

    }
}