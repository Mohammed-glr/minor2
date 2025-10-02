using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace webapp.Pages.Opdrachten.vier
{
    public class IndexModel : PageModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
        public string? ProductId { get; set; }
        public string? ProductNaam { get; set; }
        public string? ProductImg { get; set; }

        public void OnGet()
        {
            Name = HttpContext.Session.GetString("Name");
            Email = HttpContext.Session.GetString("Email");
            Address = HttpContext.Session.GetString("Address");
            ZipCode = HttpContext.Session.GetString("ZipCode");
            City = HttpContext.Session.GetString("City");
            ProductId = HttpContext.Session.GetString("ProductId");
            ProductNaam = HttpContext.Session.GetString("ProductNaam");
            ProductImg = HttpContext.Session.GetString("ProductImg");
        }

        public IActionResult OnPost()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Opdrachten/vier/Index");
        }
    }
} 