// <copyright file="BooksController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AspNetSandbox.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AspNetSandbox.DTOs;
    using AspNetSandbox.Models;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;

    /// <summary>
    ///   This controller allows us to call CRUD operations from BookService.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository repository;
        private readonly IHubContext<MessageHub> hubContext;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController"/> class.
        /// <param name="repository">Repository</param>
        /// <param name="hubContext">HubContext</param>
        /// <param name="mapper"></param>
        /// </summary>
        public BooksController(IBookRepository repository, IHubContext<MessageHub> hubContext, IMapper mapper)
        {
            this.repository = repository;
            this.hubContext = hubContext;
            this.mapper = mapper;
        }

        // GET method

        /// <summary>Gets all books.</summary>
        /// <returns>List of book objects.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var bookList = repository.GetAllBooks();
            var readBookList = mapper.Map<IEnumerable<ReadBookDto>>(bookList);
            await hubContext.Clients.All.SendAsync("BooksLoaded");
            return Ok(readBookList);
        }

        // GET method with id

        /// <summary>Gets the book by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Book object.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            try
            {
                Book book = repository.GetBookById(id);
                ReadBookDto readBookDto = mapper.Map<ReadBookDto>(book);
                return Ok(readBookDto);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST method

        /// <summary>Posts a book.</summary>
        /// <param name="bookDto">The value.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> PostBook([FromBody]CreateBookDto bookDto)
        {
            if (ModelState.IsValid)
            {
                Book book = mapper.Map<Book>(bookDto);
                repository.PostBook(book);
                await hubContext.Clients.All.SendAsync("BookCreated", book);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT method

        /// <summary>Updates an existing boom or creates a new book.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="bookDto">The value.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, [FromBody]CreateBookDto bookDto)
        {
            Book book = mapper.Map<Book>(bookDto);
            repository.PutBook(id, book);
            await hubContext.Clients.All.SendAsync("BookUpdated", book);
            return Ok();
        }

        // DELETE method

        /// <summary>Deletes the book.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            Book book = repository.GetBookById(id);
            ReadBookDto bookDto = mapper.Map<ReadBookDto>(book);
            repository.DeleteBook(bookDto.Id);
            await hubContext.Clients.All.SendAsync("BookDeleted", bookDto);
            return Ok();
        }
    }
}
