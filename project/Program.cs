using project;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        LibManager manager = new LibManager();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine
                (
                "WYBIERZ: \n 1 - Dodać książkę \n 2 - Zobacz wszystkie książki \n 3 - Dodaj czytelnika \n 4 - Wyświetl wszystkich czytelników" +
                " \n 5 - Pożycz książkę \n 6 - Zwróć książkę \n 7 - Zobacz książki czytelnika \n 8 - Usuń książkę \n 9 - Usuń czytelnika \n 0 - Wyjść"
                );

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddBook(manager);
                    break;
                case "2":
                    ShowAllBooks(manager);
                    break;
                case "3":
                    AddReader(manager);
                    break;
                case "4":
                    ShowAllReaders(manager);
                    break;
                case "5":
                    BorrowBook(manager);
                    break;
                case "6":
                    ReturnBook(manager);
                    break;
                case "7":
                    ShowReaderLoans(manager);
                    break;
                case "8":
                    RemoveBook(manager);
                    break;
                case "9":
                    RemoveReader(manager);
                    break;
                case "0":
                    exit = true;
                    Console.WriteLine("Koniec programu");
                    break;
                default:
                    Console.WriteLine("Błąd");
                    break;
            }
        }
    }

    
    //KSIĄŻKI
    static void AddBook(LibManager manager)
    {
        Console.Write("Wpisz nazwę: ");
        string title = Console.ReadLine();

        Console.Write("Wpisz autora: ");
        string author = Console.ReadLine();

        Console.Write("Wpisz rok wydania: ");
        int year = int.Parse(Console.ReadLine() ?? "0");

        Book book = new Book
        {
            Id = manager.GetNextBookId(),
            Title = title,
            Author = author,
            PublicationYear = year,
            IsAvailable = true
        };

        manager.AddBook(book);
    }

    static void ShowAllBooks(LibManager manager)
    {
        var books = manager.GetAllBooks();
        if (books.Count == 0)
        {
            Console.WriteLine("Brak");
            return;
        }

        Console.WriteLine("Książki: ");
        foreach (var b in books)
        {
            Console.WriteLine($"[ID:{b.Id}] {b.Title} - {b.Author}, rok {b.PublicationYear}, dostępność: {b.IsAvailable}");
        }
    }


    //CZYTELNICY
    static void AddReader(LibManager manager)
    {
        Console.Write("Imie: ");
        string firstName = Console.ReadLine();

        Console.Write("Nazwisko: ");
        string lastName = Console.ReadLine();

        Reader reader = new Reader
        {
            Id = manager.GetNextReaderId(),
            FName = firstName,
            LName = lastName
        };

        manager.AddReader(reader);
    }

    static void ShowAllReaders(LibManager manager)
    {
        var readers = manager.GetAllReaders();
        if (readers.Count == 0)
        {
            Console.WriteLine("Brak");
            return;
        }

        Console.WriteLine("Czytelnicy: ");
        foreach (var r in readers)
        {
            Console.WriteLine($"[ID:{r.Id}] {r.FName} {r.LName}");
        }
    }


    //WYPOŻYCZENIE
    static void BorrowBook(LibManager manager)
    {
        Console.Write("ID czytelnika: ");
        int readerId = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("ID Książki: ");
        int bookId = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Liczba dni: ");
        int days = int.Parse(Console.ReadLine() ?? "0");

        bool success = manager.BorrowBook(readerId, bookId, days);

        if (success)
        {
            Console.WriteLine("Pożyczyłeś książkę");
        }
        else
        {
            Console.WriteLine("Błąd");
        }
            
    }

    static void ReturnBook(LibManager manager)
    {
        Console.Write("ID wypożyczenia: ");
        int loanId = int.Parse(Console.ReadLine() ?? "0");

        double penalty = manager.ReturnBook(loanId);
        if (penalty < 0)
        {
            Console.WriteLine("Błąd.");
        }
        else
        {
            Console.WriteLine("Książka została zwrócona");
            Console.WriteLine($"Mandat: {penalty} pln");
        }
    }

    static void ShowReaderLoans(LibManager manager)
    {
        Console.Write("ID czytelnika: ");
        int readerId = int.Parse(Console.ReadLine() ?? "0");

        var loans = manager.GetLoansByReader(readerId);
        if (loans.Count == 0)
        {
            Console.WriteLine("Brak");
            return;
        }

        Console.WriteLine("Wypożyczone książki");
        foreach (var loan in loans)
        {
            var book = manager.GetBookById(loan.BookId);
            string returned = loan.ReturnDate == null ? /*true*/ "Nie" : /*false*/ "Tak";
            Console.WriteLine($"LoanID: {loan.LoanId}, Książka: {book?.Title}, Data wypożyczenia: {loan.BorrowDate.ToShortDateString()}, Zwrócona: {returned}");
        }
    }

    static void RemoveBook(LibManager manager)
    {
        Console.Write("ID książki: ");
        int bookId = int.Parse(Console.ReadLine() ?? "0");

        bool success = manager.RemoveBook(bookId);
        if (success)
            Console.WriteLine("Książka została usunięta");
        else
            Console.WriteLine("Błąd.");
    }

    static void RemoveReader(LibManager manager)
    {
        Console.Write("ID czytelnika: ");
        int readerId = int.Parse(Console.ReadLine() ?? "0");

        bool success = manager.RemoveReader(readerId);
        if (success)
            Console.WriteLine("Czytacz został usunięty");
        else
            Console.WriteLine("Bląd");
    }


}
