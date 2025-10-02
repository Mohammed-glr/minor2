using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace webapp.Pages.Opdrachten.twee
{
    public class Opdracht2Model : PageModel
    {
        private readonly ILogger<Opdracht2Model> _logger;

        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }

        public Opdracht2Model(ILogger<Opdracht2Model> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }
    }
}