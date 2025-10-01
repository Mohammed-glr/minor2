using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace webapp.Pages.Opdrachten
{
    public class Opdracht2234Model : PageModel
    {
        public int Id { get; set; }

        public void OnGet(int id1, int id2, int id3)
        {
            int result = id1 + id2 + id3;
            Id = result;
        }
    }
}