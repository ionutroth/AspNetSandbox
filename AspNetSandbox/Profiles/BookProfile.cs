// <copyright file="BookProfile.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AspNetSandbox.Profiles
{
    using AspNetSandbox.DTOs;
    using AspNetSandbox.Models;
    using AutoMapper;

    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookDto, Book>();

            CreateMap<Book, ReadBookDto>();
        }
    }
}
