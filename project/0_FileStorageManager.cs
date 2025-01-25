using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class FileStorageManager
    {

        //SAVE - ZAPISYWANIE PONOWNIE

        private const string BOOKS_FILE = "Books.txt";
        private const string READERS_FILE = "Readers.txt";
        private const string LOANS_FILE = "Loans.txt";
        private static char SEP = ';';

        //KSIĄŻKI


        
        public static List<Book> LoadBooks()
        {
            List<Book> books = new List<Book>();

            if (!File.Exists(BOOKS_FILE))
            {
                return books;
            }

            var lines = File.ReadAllLines(BOOKS_FILE);
            foreach (var line in lines)
            {

                if (string.IsNullOrWhiteSpace(line))
                { 
                    continue; 
                }

                var parts = line.Split(SEP);

                if (parts.Length >= 5)
                {
                    Book b = new Book
                    {
                        Id = int.Parse(parts[0]),
                        Title = parts[1],
                        Author = parts[2],
                        PublicationYear = int.Parse(parts[3]),
                        IsAvailable = bool.Parse(parts[4])
                    };
                    books.Add(b);
                }
            }

            return books;
        }


        
        public static void SaveBooks(List<Book> books)
        {
            using (StreamWriter sw = new StreamWriter(BOOKS_FILE, false))
            {
                foreach (var b in books)
                {
                    sw.WriteLine($"{b.Id}{SEP}{b.Title}{SEP}{b.Author}{SEP}{b.PublicationYear}{SEP}{b.IsAvailable}");
                }
            }
        }



        // CZYTELNICY
        public static List<Reader> LoadReaders()
        {
            List<Reader> readers = new List<Reader>();

            if (!File.Exists(READERS_FILE))
            {
                return readers;
            }

            var lines = File.ReadAllLines(READERS_FILE);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                var parts = line.Split(SEP);
                
                if (parts.Length >= 3)
                {
                    Reader r = new Reader
                    {
                        Id = int.Parse(parts[0]),
                        FName = parts[1],
                        LName = parts[2]
                    };
                    readers.Add(r);
                }
            }
            return readers;
        }

        public static void SaveReaders(List<Reader> readers)
        {
            using (StreamWriter sw = new StreamWriter(READERS_FILE, false))
            {
                foreach (var r in readers)
                {
                    sw.WriteLine($"{r.Id}{SEP}{r.FName}{SEP}{r.LName}");
                }
            }
        }



        // POŻYCZKI
        public static List<Loan> LoadLoans()
        {
            List<Loan> loans = new List<Loan>();

            if (!File.Exists(LOANS_FILE))
            {
                return loans;
            }

            var lines = File.ReadAllLines(LOANS_FILE);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                var parts = line.Split(SEP);
                
                if (parts.Length >= 7)
                {
                    Loan ln = new Loan
                    {
                        LoanId = int.Parse(parts[0]),
                        BookId = int.Parse(parts[1]),
                        ReaderId = int.Parse(parts[2]),
                        BorrowDate = DateTime.Parse(parts[3]),
                        DueDate = DateTime.Parse(parts[4]),
                        ReturnDate = string.IsNullOrEmpty(parts[5]) ? (DateTime?)null : DateTime.Parse(parts[5]),
                        Penalty = double.Parse(parts[6])
                    };
                    loans.Add(ln);
                }
            }
            return loans;
        }

        public static void SaveLoans(List<Loan> loans)
        {
            using (StreamWriter sw = new StreamWriter(LOANS_FILE, false))
            {
                foreach (var ln in loans)
                {
                    string retDate = ln.ReturnDate.HasValue ? ln.ReturnDate.Value.ToString() : "";
                    sw.WriteLine($"{ln.LoanId}{SEP}{ln.BookId}{SEP}{ln.ReaderId}{SEP}{ln.BorrowDate}{SEP}{ln.DueDate}{SEP}{retDate}{SEP}{ln.Penalty}");
                }
            }
        }
    }
}
