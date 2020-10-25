using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ProductApp.Models;

namespace ProductApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        //opret en tom liste med produkter
        public List<Product> Products { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public List<Product> GetProducts()
        {
            //få serverens adresse
            var serverAddress = HttpContext.Request.Host;

            //læs json filen
            WebClient client = new WebClient();
            var json = client.DownloadString($"https://{serverAddress}/data/products.json");

            //deserialisere json
            var result = JsonSerializer.Deserialize<List<Product>>(json);

            return result;
        }
    }
}
