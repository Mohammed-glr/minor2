using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Microsoft.Data.Sqlite;

namespace webapp.Pages.Opdrachten.zes
{
    public class Product
    {
        public int ArtikelNr { get; set; }
        public string Naam { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Omschrijving { get; set; } = string.Empty;
        public decimal Prijs { get; set; }
    }

    public class ProductData
    {
        SqliteConnection connection;

        public List<Product> Products { get; set; } = new();

        public ProductData()
        {
            SqliteConnectionStringBuilder connectionStringBuilder = new();
            connectionStringBuilder.DataSource = "./Db/LekkerZitten.db";
            connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
        }

        public void LoadProducts()
        {
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText =
            @"
                SELECT artikelnr, naam, type, omschijving, prijs FROM meubels
            ";

            using SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Product product = new()
                {
                    ArtikelNr = reader.GetInt32(0),
                    Naam = reader.GetString(1),
                    Type = reader.GetString(2),
                    Omschrijving = reader.GetString(3),
                    Prijs = reader.GetDecimal(4)
                };
                Products.Add(product);
            }

            connection.Close();
        }


    }

   public class Opdracht6Model : PageModel

    {

        public string Name { get; set; } = string.Empty;

        public List<Product> Producten { get; set; } = new List<Product>();



        public void OnGet()

        {
            ProductData productData = new ProductData();
            productData.LoadProducts();
            Producten = productData.Products;

        }
    }
}
