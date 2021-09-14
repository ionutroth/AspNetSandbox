﻿// <copyright file="BooksController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AspNetSandbox.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AspNetSandbox.Data;
    using AspNetSandbox.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    ///   This controller allows us to call CRUD operations from BookService.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController"/> class.
        /// </summary>
        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET method

        /// <summary>Gets all books.</summary>
        /// <returns>List of book objects.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            return Ok(await _context.Book.ToListAsync());
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
                Book book = await GetBookInstance(id);
                return Ok(book);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        private async Task<Book> GetBookInstance(int id)
        {
            return await _context.Book
                            .FirstOrDefaultAsync(m => m.Id == id);
        }

        // POST method

        /// <summary>Posts a book.</summary>
        /// <param name="book">The value.</param>
        [HttpPost]
        public async Task<IActionResult> PostBook([FromBody]Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
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
        /// <param name="book">The value.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, [FromBody]Book book)
        {
            var selectedBook = await GetBookInstance(id);
            selectedBook.Title = book.Title;
            selectedBook.Author = book.Author;
            selectedBook.Language = book.Language;
            _context.Update(selectedBook);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE method

        /// <summary>Deletes the book.</summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Book.FindAsync(id);
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
