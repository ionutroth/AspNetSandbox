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
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return bookService.Get();
        }
        
        [HttpGet("{id}")]  
        public Book Get(int id)
        {
            return bookService.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]Book value)
        {
            bookService.Post(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bookService.Delete(id);
        }
    }
}
