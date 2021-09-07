﻿using System.Collections.Generic;

namespace AspNetSandbox
{
    public interface IBookService
    {
        void Delete(int id);
        IEnumerable<Book> Get();
        Book Get(int id);
        void Post(Book value);
        void Put(int id, string value);
    }
}