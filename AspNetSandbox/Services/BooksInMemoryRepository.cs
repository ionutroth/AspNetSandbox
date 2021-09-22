// <copyright file="BooksInMemoryRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AspNetSandbox.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AspNetSandbox.Models;

    /// <summary>Implement CRUD operations.</summary>
    public class BooksInMemoryRepository : IBookRepository
    {
        private static List<Book> books;

        /// <summary>
        /// Initializes static members of the <see cref="BooksInMemoryRepository"/> class.
        /// Initializes the Bookservice class with 2 Book objects.
        /// </summary>
        static BooksInMemoryRepository()
        {
            books = new List<Book>();
            books.Add(new Book
            {
                Id = 1,
                Title = "ceva",
                Author = "ceva autor",
                Language = "ceva limba",
            });
            books.Add(new Book
            {
                Id = 2,
                Title = "ceva2",
                Author = "ceva autor2",
                Language = "ceva limba2",
            });
        }

        /// <summary>Gets all books.</summary>
        /// <returns>Book list.</returns>
        public IEnumerable<Book> GetAllBooks()
        {
            return books;
        }

        /// <summary>Gets the book by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Book object.</returns>
        public Book GetBookById(int id)
        {
            return books.Single(book => book.Id == id);
        }

        /// <summary>Posts the book.</summary>
        /// <param name="value">The value.</param>
        public void PostBook(Book value)
        {
            var sortedBooks = books.OrderBy(book => book.Id).ToList();
            value.Id = sortedBooks[sortedBooks.Count - 1].Id + 1;
            books.Add(value);
        }

        /// <summary>Updates or creates a value from book list.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        public void PutBook(int id, Book value)
        {
            var selectedBook = books.Find(book => book.Id == id);
            if (books.Exists(book => book.Id == id))
            {
                selectedBook.Title = value.Title;
                selectedBook.Author = value.Author;
                selectedBook.Language = value.Language;
            }
            else
            {
                value.Id = id;
                books.Add(value);
            }
        }

        /// <summary>Deletes the book object with set id.</summary>
        /// <param name="id">The identifier.</param>
        public void DeleteBook(int id)
        {
            books.Remove(GetBookById(id));
        }
    }
}