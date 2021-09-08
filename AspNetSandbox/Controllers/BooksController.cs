using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AspNetSandbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        // GET method
        [HttpGet]
        public IEnumerable<Book> GetAllBooks()
        {
            return bookService.GetAllBooks();
        }

        // GET method with id
        [HttpGet("{id}")]
        public ActionResult GetBookById(int id)
        {
            try
            {
                return Ok(bookService.GetBookById(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // Post method
        [HttpPost]
        public void PostBook([FromBody]Book value)
        {
            bookService.PostBook(value);
        }

        // Put method
        [HttpPut("{id}")]
        public void PutBook(int id, [FromBody]Book value)
        {
            bookService.PutBook(id, value);
        }

        // DELETE method
        [HttpDelete("{id}")]
        public void DeleteBook(int id)
        {
            bookService.DeleteBook(id);
        }
    }
}
