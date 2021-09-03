using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetSandbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BookController: ControllerBase
    {
        private Book[] books;
        public BookController()
        {
            books = new Book[2];
            books[0] = new Book() {
                Id = 1,
                Title = "ceva",
                Author = "ceva autor",
                Language = "ceva limba"
            };
            books[1] = new Book() {
                Id = 2,
                Title = "ceva2",
                Author = "ceva autor2",
                Language = "ceva limba2"
            };
        }   
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return books;
        }
        
        [HttpGet("{id}")]  
        public Book Get(int id)
        {
            return books.Single(SomeFunction);
        }
        
        private bool SomeFunction(Book book)
        {
            return book.Id == 1;
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        [HttpPut]
        public Book Put()
    }
}
