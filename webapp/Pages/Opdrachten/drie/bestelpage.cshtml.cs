using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webapp.Pages.Opdrachten.drie
{
    public class BestelpageModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;

        public Product? SelectedProduct { get; set; }
        public bool ProductNotFound { get; set; }

        public BestelpageModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public void OnGet(int? productId)
        {
            if (productId.HasValue)
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
    }
}
   