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
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public int Age { get; private set; }

    public Person(string firstName, string lastName, int wiek)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = wiek;
    }

    public virtual void View()
    {
        Console.WriteLine($"Name: {FirstName}, lastname: {LastName}, age: {Age}");
    }
}



class Book
{
    public string Title { get; private set; }
    public Person Author { get; private set; }
    public int DataWydania { get; private set; }

    public Book(string title, Person author, int dataWydania)
    {
        Title = title;
        Author = author;
        DataWydania = dataWydania;
    }
    public void View()
    {
        Console.WriteLine($"Title: {Title}, date: {DataWydania}");
        Console.Write("Author:");
        Author.View();
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
    protected List<Book> ReadBooks { get; set; } = new List<Book>();

    public Reader(string firstName, string lastName, int age) : base(firstName, lastName, age)
    {

    }

    public void AddBook(Book book)
    {
        ReadBooks.Add(book);
    }

    public void ViewBooks()
    {
        Console.WriteLine($"{FirstName} {LastName} books:");

        foreach (var book in ReadBooks)
        {
            Console.WriteLine($" {book.Title}");
        }
    }

    public override void View()
    {
        base.View();
        ViewBooks();
    }
}

/*
Zadanie 1 f
Utwórz klasę Reviewer dziedziczącą z klasy Reader. Wypisz () recenzenta powinno wypisać listę książek,
które przeczytał, a obok każdej pozycji losową ocenę (różną dla każdego wykonania metody Wypisz ()).
Czy do stworzenia takiej funkcjonalności konieczne jest aby lista książek w klasie Reader była protected?
Czy też może posiadać widoczność private? Utwórz 2 recenzentów, przypisz im książki i wykonaj
stworzoną metodę
*/

class Reviewer : Reader
{
    public Reviewer(string firstName, string lastName, int age) : base(firstName, lastName, age)
    {

    }

    public override void View()
    {
        base.View();

        Console.WriteLine("With ratings:");

        var random = new Random();

        foreach (var book in ReadBooks)
        {
            Console.WriteLine($"{book.Title}: {random.Next(1, 11)}/10");
        }
    }
}


/*
Zadanie 1 g
W Main stwórz listę obiektów klasy Person (List<Person>) dodaj do niej zarówno Reader jak i Reviewer.
W pętli wykonaj metodę View na wszystkich obiektach z listy.

Zadanie 1 h
Zmień widoczność pól w klasie Book na protected. W razie konieczności dodaj konstruktor i popraw
istniejące klasy, aby program dalej działał poprawnie
*/

class Program
{
    static void Main(string[] args)
    {
       
        var author1 = new Person("Andrzej", "Sapkowski", 45);
        var author2 = new Person("Stiven", "King", 69);

        var book1 = new Book("Witcher", author1, 2000);
        var book2 = new Book("It", author2, 2010);

        var reader1 = new Reader("Ostap", "Holoborodko", 18);
        var reader2 = new Reader("Tima", "Aliexpress", 19);

        reader1.AddBook(book1);
        reader2.AddBook(book2);

        var reviewer1 = new Reviewer("Big", "Boss", 799);
        reviewer1.AddBook(book1);
        reviewer1.AddBook(book2);

        List<Person> people = new List<Person> { reader1, reader2, reviewer1 };

        foreach (var person in people)
        {
            person.View();
            Console.WriteLine();
        }
    }
}