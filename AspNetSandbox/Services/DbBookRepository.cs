// <copyright file="DbBookRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AspNetSandbox.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AspNetSandbox.Data;
    using AspNetSandbox.Models;

    public class DbBookRepository : IBookRepository
    {
        private readonly ApplicationDbContext context;

        public DbBookRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void DeleteBook(int id)
        {
            var book = context.Book.Find(id);
            context.Book.Remove(book);
            context.SaveChanges();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return context.Book.ToList();
        }

        public Book GetBookById(int id)
        {
            Book book = context.Book.FirstOrDefault(m => m.Id == id);
            return book;
        }

        public void PostBook(Book book)
        {
            context.Add(book);
            context.SaveChanges();
        }

        public void PutBook(int id, Book book)
        {
            book.Id = id;
            context.Update(book);
            context.SaveChanges();
        }
    }
}
