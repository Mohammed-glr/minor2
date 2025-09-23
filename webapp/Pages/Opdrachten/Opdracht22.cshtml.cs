using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace webapp.Pages.Opdrachten
{
    public class Opdracht22Model : PageModel
    {
        private readonly ILogger<Opdracht22Model> _logger;

        [BindProperty(SupportsGet = true)]
        public int? Id1 { get; set; }

        public Opdracht22Model(ILogger<Opdracht22Model> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
} 