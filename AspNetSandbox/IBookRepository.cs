// <copyright file="IBookRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AspNetSandbox
{
    using System.Collections.Generic;
    using AspNetSandbox.Models;

    public interface IBookRepository
    {
        void DeleteBook(int id);

        IEnumerable<Book> GetAllBooks();

        Book GetBookById(int id);

        void PostBook(Book book);

        void PutBook(int id, Book value);
    }
}