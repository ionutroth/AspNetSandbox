using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandbox
{
    public class BookService : IBookService
    {

        private static List<Book> books;
        private static int id = 0;
        static BookService()
        {
            books = new List<Book>();
            books.Add(new Book {
                Id = 1,
                Title = "ceva",
                Author = "ceva autor",
                Language = "ceva limba"
            });
            books.Add(new Book {
                Id = 2,
                Title = "ceva2",
                Author = "ceva autor2",
                Language = "ceva limba2"
            });
        }
        public IEnumerable<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetBookById(int id)
        {
            return books.Single(book => book.Id == id);
        }

        public void PostBook(Book value)
        {
            var sortedBooks = books.OrderBy(book => book.Id).ToList();
            value.Id = sortedBooks[sortedBooks.Count - 1].Id + 1;
            books.Add(value);
        }

        public void PutBook(int id, Book value)
        {
            var selectedBook = books.Find(book => book.Id == id);
            if (books.Exists(book => book.Id == id)) {
                selectedBook.Title = value.Title;
                selectedBook.Author = value.Author;
                selectedBook.Language = value.Language;
            }
            else{
                value.Id = id;
                books.Add(value);
            }
        }

        public void DeleteBook(int id)
        {
            books.Remove(GetBookById(id));
        }

        public void ResetId()
        {
            id = 0;
        }
    }
}