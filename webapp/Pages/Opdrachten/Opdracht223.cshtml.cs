using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace webapp.Pages.Opdrachten
{
    public class Opdracht223Model : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id1 { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id2 { get; set; }

        public void OnGet()
        {
            
        }
    }
}