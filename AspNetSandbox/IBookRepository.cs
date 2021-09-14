using AspNetSandbox.Models;
using System;
using System.Collections.Generic;

namespace AspNetSandbox
{
    public interface IBookRepository
    {
        void DeleteBook(int id);

        IEnumerable<Book> GetAllBooks();

        Book GetBookById(int id);

        void PostBook(Book value);

        void PutBook(int id, Book value);
        Book FirstOrDefault(Func<object, bool> p);
    }
}