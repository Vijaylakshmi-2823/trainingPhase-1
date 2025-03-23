using NUnit.Framework;
using LibraryManagement; // Add this line
using System;
using System.IO;
using System.Linq;

namespace LibraryTests
{
    [TestFixture]
    public class LibraryTests
    {
        private Library _library;
        private Book _book;
        private Borrower _borrower;

        public object Borrowers { get; private set; }

        [SetUp]
        public void Setup()
        {
            _library = new Library();
            _book = new Book("C# Fundamentals", "John Doe", "12345");
            _borrower = new Borrower("Alice", "ABC123");
        }

        [Test]
        public void AddBook_ShouldAddBookToLibrary()
        {
            _library.AddBook(_book);
            Assert.That(_library.Books.Contains(_book), Is.True);
        }


       
        public void RegisterBorrower_ShouldAddBorrowerToLibrary()
        {
            _library.RegisterBorrower(_borrower);
            Assert.That(_library._borrower, Contains.Item(Borrowers));
        }

        [Test]
        public void BorrowBook_ShouldMarkBookAsBorrowed()
        {
            _library.AddBook(_book);
            _library.RegisterBorrower(_borrower);
            _library.BorrowBook("12345", "ABC123");

            
            Assert.That(_borrower.BorrowedBooks.Contains(_book), Is.True);
        }


        [Test]
        public void ReturnBook_ShouldMarkBookAsAvailable()
        {
            _library.AddBook(_book);
            _library.RegisterBorrower(_borrower);
            _library.BorrowBook("12345", "ABC123");
            _library.ReturnBook("12345", "ABC123");

            
            Assert.That(_borrower.BorrowedBooks, Is.Empty);
        }



        [Test]
        public void ViewBooks_ShouldDisplayBooks()
        {
            _library.AddBook(_book);
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                _library.ViewBooks();
                string expected = "C# Fundamentals by John Doe - Available";
                Assert.That(sw.ToString().Contains(expected));
            }
        }

        [Test]
        public void ViewBorrowers_ShouldDisplayBorrowers()
        {
            _library.RegisterBorrower(_borrower);
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                _library.ViewBorrowers();
                string expected = "Alice (ABC123) - Books Borrowed: 0";
                Assert.That(sw.ToString().Contains(expected),Is.True);
            }
        }
    }
}
