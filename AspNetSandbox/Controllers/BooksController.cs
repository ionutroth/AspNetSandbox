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
        private readonly IBookService bookService;
        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        //GET method
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return bookService.Get();
        }
        
        //GET method with id
        [HttpGet("{id}")]  
        public Book Get(int id)
        {
            return bookService.Get(id);
        }

        //Post method 
        [HttpPost]
        public void Post([FromBody]Book value)
        {
            bookService.Post(value);
        }

        //Put method
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Book value)
        {
            bookService.Put(id, value);
        }

        //DELETE method
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bookService.Delete(id);
        }
    }
}
