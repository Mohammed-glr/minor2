using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace webapp.Pages.Opdrachten.drie
{
    public class Product
    {
        public int Id { get; set; }
        public string Naam { get; set; } = string.Empty;
        public decimal Prijs { get; set; }
        public string Beschrijving { get; set; } = string.Empty;
        public string Img { get; set; } = string.Empty;
        public string Categorie { get; set; } = string.Empty;
        public int Voorraad { get; set; }
        public double Rating { get; set; }
    }

    public class ProductData
    {
        public List<Product> Producten { get; set; } = new();
    }

    public class Opdracht3Model : PageModel
    {
        private readonly ILogger<Opdracht3Model> _logger;
        private readonly IWebHostEnvironment _environment;

        public List<Product> Producten { get; set; } = new();

        public Opdracht3Model(ILogger<Opdracht3Model> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public void OnGet(
            string? productId
        )
        {
            var jsonPath = Path.Combine(_environment.ContentRootPath, "Pages", "Opdrachten", "drie", "data.json");

            if (System.IO.File.Exists(jsonPath))
            {
                var jsonString = System.IO.File.ReadAllText(jsonPath);
                var data = JsonSerializer.Deserialize<ProductData>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (data != null)
                {
                    Producten = data.Producten;
                }
            }
            
            if (!string.IsNullOrEmpty(productId) && int.TryParse(productId, out int prodId))
            {
                Producten = Producten.Where(p => p.Id == prodId).ToList();
            }
        }
    }
}
