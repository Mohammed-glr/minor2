using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace webapp.Pages.Opdrachten.vijf
{
    public class BestelpageModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;

        public Product? SelectedProduct { get; set; }
        public bool ProductNotFound { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }

        public BestelpageModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public void OnGet(int? productId, string? name, string? email, string? address, string? zipCode, string? city)
        {
            if (name != null)
            {
                Name = name;
            }
            if (email != null)
            {
                Email = email;
            }
            if (address != null)
            {
                Address = address;
            }
            if (zipCode != null)
            {
                ZipCode = zipCode;
            }
            if (city != null)
            {
                City = city;
            }
            if (productId.HasValue)
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
                        SelectedProduct = data.Producten.FirstOrDefault(p => p.Id == productId.Value);
                        ProductNotFound = SelectedProduct == null;
                    }
                }
            }
            else
            {
                ProductNotFound = true;
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
            if (!string.IsNullOrEmpty(productId))
            {
                HttpContext.Session.SetString("ProductId", productId);
                HttpContext.Session.SetString("ProductNaam", productNaam);
                HttpContext.Session.SetString("ProductImg", productImg);
            }

            return RedirectToPage("/Opdrachten/vier/Index");
        }
    }
}
   