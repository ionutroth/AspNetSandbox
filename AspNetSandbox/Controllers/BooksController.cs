using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetSandbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BooksController: ControllerBase
    {
        private static List<Book> books;
        static BooksController()
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
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return books;
        }
        
        [HttpGet("{id}")]  
        public Book Get(int id)
        {
            return books.Single(book=>book.Id == id);
        }

        [HttpPost]
        public void Post([FromBody]Book value)
        {
            var id = books.Count + 1;
            value.Id = id;
            books.Add(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            books.Remove(Get(id));
        }
    }
}
