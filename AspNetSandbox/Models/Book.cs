﻿// <copyright file="Book.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AspNetSandbox.Models
{
    using System.Diagnostics;

    [DebuggerDisplay("Title = {Title} Id = {Id}")]
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Language { get; set; }

        public decimal PurchasePrice { get; set; }
    }
}
