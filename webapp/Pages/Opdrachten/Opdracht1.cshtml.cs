using Microsoft.AspNetCore.Mvc.RazorPages;


namespace webapp.Pages.Opdrachten
{
    public class Opdracht1Model : PageModel
    {
        private readonly ILogger<Opdracht1Model> _logger;
        public string MijnNaam { get; set; } = "Onbekend";
        public int Leeftijd { get; set; } = 0;
        public string Stad { get; set; } = "Onbekend";
        
        public Opdracht1Model(ILogger<Opdracht1Model> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string? naam = Request.Query["mijnNaam"];
            if (!string.IsNullOrEmpty(naam))
            {
                MijnNaam = naam;
            }

            if (int.TryParse(Request.Query["leeftijd"], out int leeftijd))
            {
                Leeftijd = leeftijd;
            }

            string? stad = Request.Query["stad"];
            if (!string.IsNullOrEmpty(stad))
            {
                Stad = stad;
            }
        }
    }
}
