using System.Threading.Tasks;
using AspNetSandbox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandbox.Pages.Books
{
    public class DeleteModel : PageModel
    {
        private readonly Data.ApplicationDbContext context;
        private readonly IHubContext<MessageHub> hubContext;

        public DeleteModel(Data.ApplicationDbContext context, IHubContext<MessageHub> hubContext)
        {
            this.context = context;
            this.hubContext = hubContext;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await this.context.Book.FirstOrDefaultAsync(m => m.Id == id);

            if (Book == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await this.context.Book.FindAsync(id);

            if (Book != null)
            {
                this.context.Book.Remove(Book);
                await this.context.SaveChangesAsync();
                await hubContext.Clients.All.SendAsync("BookDeleted", Book);
            }

            return RedirectToPage("./Books");
        }
    }
}
