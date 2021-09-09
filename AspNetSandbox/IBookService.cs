using AspNetSandbox.Models;
using System.Collections.Generic;

namespace AspNetSandbox
{
    public interface IBookService
    {
        void DeleteBook(int id);

        IEnumerable<Book> GetAllBooks();

        Book GetBookById(int id);

        void PostBook(Book value);

        void PutBook(int id, Book value);
    }
}