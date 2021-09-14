using AspNetSandbox.Data;
using AspNetSandbox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandbox.Services
{
    public class DbBookRepository : IBookRepository
    {
        private readonly ApplicationDbContext context;

        public DbBookRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void DeleteBook(int id)
        {
            throw new NotImplementedException();
            var book = context.Book.Find(id);
            context.Book.Remove(book);
            context.SaveChanges();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            throw new NotImplementedException();
            return context.Book.ToList();
        }

        public Book GetBookById(int id)
        {
            Book book = GetBookById(id);
            return book;
        }

        public void PostBook(Book book)
        {
            throw new NotImplementedException();
            context.Add(book);
            context.SaveChanges();
        }

        public void PutBook(int id, Book book)
        {
            throw new NotImplementedException();
            var selectedBook = GetBookById(id);
            selectedBook.Title = book.Title;
            selectedBook.Author = book.Author;
            selectedBook.Language = book.Language;
            context.Update(selectedBook);
            context.SaveChanges();
        }
    }
}
