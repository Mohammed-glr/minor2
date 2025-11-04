using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace webapp.Pages.Opdrachten.vijf
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

    public class Opdracht5Model : PageModel
    {
        private readonly ILogger<Opdracht5Model> _logger;
        private readonly IWebHostEnvironment _environment;

        public List<Product> Producten { get; set; } = new();
        public string? Name { get; set; }

            public Opdracht5Model(ILogger<Opdracht5Model> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public void OnGet(
            string? productId,
            string? name
        )
        {
            var jsonPath = Path.Combine(_environment.ContentRootPath, "Pages", "Opdrachten", "vier", "data.json");

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

            if (!string.IsNullOrEmpty(name))
            {
                Name = name;
            }
        }
        
         public IActionResult OnPost()
        {  
            var name = Request.Form["Name"].ToString();
            var email = Request.Form["email"].ToString();
            var address = Request.Form["address"].ToString();
            var zipCode = Request.Form["zipCode"].ToString();
            var city = Request.Form["city"].ToString();
            var productId = Request.Form["productId"].ToString();
            var productNaam = Request.Form["productNaam"].ToString();
            var productImg = Request.Form["productImg"].ToString();
            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetString("Email", email);
            HttpContext.Session.SetString("Address", address);
            HttpContext.Session.SetString("ZipCode", zipCode);
            HttpContext.Session.SetString("City", city);
            if (!string.IsNullOrEmpty(productId) && !string.IsNullOrEmpty(productNaam) && !string.IsNullOrEmpty(productImg))
            {
                HttpContext.Session.SetString("ProductId", productId);
                HttpContext.Session.SetString("ProductNaam", productNaam);
                HttpContext.Session.SetString("ProductImg", productImg);
            }

            return RedirectToPage("/Opdrachten/vijf/Index");
        }
    }
}
