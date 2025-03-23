using System.Collections.Generic;
using System;
using System.Linq;

namespace LibraryManagement
{
    public class Library
    {
        public List<Book> Books { get; }
        public List<Borrower> Borrowers { get; }

        public Library()
        {
            Books = new List<Book>();
            Borrowers = new List<Borrower>();
        }

        public void AddBook(Book book) => Books.Add(book);
        public void RegisterBorrower(Borrower borrower) => Borrowers.Add(borrower);

        public bool BorrowBook(string isbn, string libraryCardNumber)
        {
            var book = Books.FirstOrDefault(b => b.ISBN == isbn && !b.IsBorrowed);
            var borrower = Borrowers.FirstOrDefault(b => b.LibraryCardNumber == libraryCardNumber);

            if (book != null && borrower != null)
            {
                borrower.BorrowBook(book);
                return true;
            }
            return false;
        }

        public bool ReturnBook(string isbn, string libraryCardNumber)
        {
            var borrower = Borrowers.FirstOrDefault(b => b.LibraryCardNumber == libraryCardNumber);
            var book = borrower?.BorrowedBooks.FirstOrDefault(b => b.ISBN == isbn);

            if (book != null)
            {
                borrower.ReturnBook(book);
                return true;
            }
            return false;
        }

        public void ViewBooks()
        {
            foreach (var book in Books)
            {
                Console.WriteLine($"{book.Title} by {book.Author} - {(book.IsBorrowed ? "Borrowed" : "Available")}");
            }
        }

        public void ViewBorrowers()
        {
            foreach (var borrower in Borrowers)
            {
                Console.WriteLine($"{borrower.Name} ({borrower.LibraryCardNumber}) - Books Borrowed: {borrower.BorrowedBooks.Count}");
            }
        }

        public bool _borrower()
        {
            throw new NotImplementedException();
        }
    }
}
