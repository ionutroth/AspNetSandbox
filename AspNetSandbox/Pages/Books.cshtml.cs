using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSandbox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandbox.Pages.Books
{
    public class BooksModel : PageModel
    {
        private readonly AspNetSandbox.Data.ApplicationDbContext context;

        public BooksModel(AspNetSandbox.Data.ApplicationDbContext context)
        {
            this.context = context;
        }

        public IList<Book> Book { get; set; }

        public async Task OnGetAsync()
        {
            Book = await this.context.Book.ToListAsync();
        }
    }
}
