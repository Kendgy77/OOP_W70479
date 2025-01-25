using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class LibManager
    {
        private List<Book> _books;
        private List<Reader> _readers;
        private List<Loan> _loans;

        private const double PENALTY_RATE = 2.0;

        public LibManager()
        {
           
            _books = FileStorageManager.LoadBooks();
            _readers = FileStorageManager.LoadReaders();
            _loans = FileStorageManager.LoadLoans();
        }

        
        public int GetNextBookId()
        {
            if (_books.Count == 0)
            {
                return 1;
            }

            return _books.Max(b => b.Id) + 1;
        }
        public int GetNextReaderId()
        {
            if (_readers.Count == 0)
            {
                return 1;
            };

            return _readers.Max(r => r.Id) + 1;
        }
        public int GetNextLoanId()
        {
            if (_loans.Count == 0)
            {
                return 1;
            }

            return _loans.Max(l => l.LoanId) + 1;
        }


        //CRUD KSIĄŻKI
        public void AddBook(Book book)
        {
            _books.Add(book);
            FileStorageManager.SaveBooks(_books);
        }

        public bool RemoveBook(int bookId)
        {

            var book = _books.FirstOrDefault(b => b.Id == bookId);
            if (book != null)
            {
                _books.Remove(book);
                FileStorageManager.SaveBooks(_books);
                return true;
            }
            return false;
        }

        public List<Book> GetAllBooks()
        {
            return _books;
        }

        public Book GetBookById(int bookId)
        {
            return _books.FirstOrDefault(b => b.Id == bookId);
        }


        //CRUD CZYTELNICY
        public void AddReader(Reader reader)
        {
            _readers.Add(reader);
            FileStorageManager.SaveReaders(_readers);
        }

        public bool RemoveReader(int readerId)
        {

            var reader = _readers.FirstOrDefault(r => r.Id == readerId);

            if (reader != null)
            {
                _readers.Remove(reader);
                FileStorageManager.SaveReaders(_readers);
                return true;
            }
            return false;
        }

        public List<Reader> GetAllReaders()
        {
            return _readers;
        }

        public Reader GetReaderById(int id)
        {
            return _readers.FirstOrDefault(r => r.Id == id);
        }




        // WYPOŻYCZENIE
        public bool BorrowBook(int readerId, int bookId, int days)
        {
            var reader = GetReaderById(readerId);
            var book = GetBookById(bookId);

            if (reader == null || book == null)
            {
                return false;
            }

            if (!book.IsAvailable)
            {
                return false;
            }
     
            Loan newLoan = new Loan
            {
                LoanId = GetNextLoanId(),
                BookId = bookId,
                ReaderId = readerId,
                BorrowDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(days),
                ReturnDate = null,
                Penalty = 0
            };

            _loans.Add(newLoan);
            book.IsAvailable = false;

            
            FileStorageManager.SaveBooks(_books);
            FileStorageManager.SaveLoans(_loans);

            return true;
        }

        
        public double ReturnBook(int loanId)
        {
            var loan = _loans.FirstOrDefault(l => l.LoanId == loanId);
            if (loan == null)
            {
                return -1;
            }


            loan.ReturnDate = DateTime.Now;
            
            if (loan.ReturnDate > loan.DueDate)
            {
                int delayDays = (loan.ReturnDate.Value - loan.DueDate).Days;
                loan.Penalty = delayDays * PENALTY_RATE;
            }

            
            var book = _books.FirstOrDefault(b => b.Id == loan.BookId);
            if (book != null)
            {
                book.IsAvailable = true;
            }

            
            FileStorageManager.SaveBooks(_books);
            FileStorageManager.SaveLoans(_loans);

            return loan.Penalty;
        }

        public List<Loan> GetLoansByReader(int readerId)
        {
            var reader = GetReaderById(readerId);
            if (reader == null)
            {
                return new List<Loan>();
            }
            return _loans.Where(l => l.ReaderId == readerId).ToList();
        }
    }
}
