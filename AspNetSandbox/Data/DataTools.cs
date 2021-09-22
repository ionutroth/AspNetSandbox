// <copyright file="DataTools.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AspNetSandbox.Data
{
    using System;
    using System.Linq;
    using AspNetSandbox.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    public static class DataTools
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var appDbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                if (appDbContext.Book.Any())
                {
                    Console.WriteLine("DB contains books.");
                }
                else
                {
                    Console.WriteLine("DB does not contain books.");
                    var book1 = new Book();
                    var book2 = new Book();

                    book1.Title = "bookTitle1";
                    book1.Author = "bookAuthor1";
                    book1.Language = "bookLanguage1";

                    book2.Title = "bookTitle2";
                    book2.Author = "bookAuthor2";
                    book2.Language = "bookLanguage2";

                    appDbContext.Add(book1);
                    appDbContext.Add(book2);
                    appDbContext.SaveChanges();
                }
            }
        }
    }
}
