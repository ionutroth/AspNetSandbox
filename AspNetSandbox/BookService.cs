using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandbox
{
    public class BookService : IBookService, IBookService
    {

        private static List<Book> books;
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
        public IEnumerable<Book> Get()
        {
            return books;
        }

        public Book Get(int id)
        {
            return books.Single(book => book.Id == id);
        }

        public void Post(Book value)
        {
            var id = books.Count + 1;
            value.Id = id;
            books.Add(value);
        }

        public void Put(int id, string value)
        {

        }
        public void Delete(int id)
        {
            books.Remove(Get(id));
        }
    }
}

