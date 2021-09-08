using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AspNetSandbox.Controllers
{
    /// <summary>
    ///   This controller allows us to call CRUD operations from BookService.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService bookService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController"/> class.
        /// </summary>
        /// <param name="bookService">The service.</param>
        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        // GET method

        /// <summary>Gets all books.</summary>
        /// <returns>List of book objects.</returns>
        [HttpGet]
        public IEnumerable<Book> GetAllBooks()
        {
            return bookService.GetAllBooks();
        }

        // GET method with id

        /// <summary>Gets the book by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Book object.</returns>
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

        // POST method

        /// <summary>Posts a book.</summary>
        /// <param name="value">The value.</param>
        [HttpPost]
        public void PostBook([FromBody]Book value)
        {
            bookService.PostBook(value);
        }

        // PUT method

        /// <summary>Updates an existing boom or creates a new book.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        [HttpPut("{id}")]
        public void PutBook(int id, [FromBody]Book value)
        {
            bookService.PutBook(id, value);
        }

        // DELETE method

        /// <summary>Deletes the book.</summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public void DeleteBook(int id)
        {
            bookService.DeleteBook(id);
        }
    }
}
