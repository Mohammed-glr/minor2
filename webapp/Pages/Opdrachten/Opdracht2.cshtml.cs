using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webapp.Pages.Opdrachten
{
    public class Opdracht2Model : PageModel
    {
        private readonly ILogger<Opdracht2Model> _logger;

        public Opdracht2Model(ILogger<Opdracht2Model> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}