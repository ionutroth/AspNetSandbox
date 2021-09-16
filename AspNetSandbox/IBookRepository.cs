using System.Collections.Generic;
using AspNetSandbox.Models;

namespace AspNetSandbox
{
    public interface IBookRepository
    {
        void DeleteBook(int id);

        IEnumerable<Book> GetAllBooks();

        Book GetBookById(int id);

        void PostBook(Book book);

        void PutBook(int id, Book value);
    }
}