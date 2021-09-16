using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSandbox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;

namespace AspNetSandbox.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Data.ApplicationDbContext context;
        private readonly IHubContext<MessageHub> hubContext;

        public CreateModel(Data.ApplicationDbContext context, IHubContext<MessageHub> hubContext)
        {
            this.context = context;
            this.hubContext = hubContext;
        }

        [BindProperty]
        public Book Book { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await hubContext.Clients.All.SendAsync("BookCreated");
            this.context.Book.Add(Book);
            await this.context.SaveChangesAsync();

            return RedirectToPage("./Books");
        }
    }
}
