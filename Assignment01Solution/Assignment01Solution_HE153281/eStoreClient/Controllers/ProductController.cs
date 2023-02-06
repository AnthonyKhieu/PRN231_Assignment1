using BusinessObject;
using eStoreAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace eStoreClient.Controllers
{
    public class ProductController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44336/api");
        HttpClient client;
        public ProductController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public ActionResult Index(string search)
        {
            List<Product> products = new List<Product>();

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"/ProductsAPI?search={search}").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                products = JsonSerializer.Deserialize<List<Product>>(data, options);


            }
            ViewData["key"] = search;
            return View(products);
        }
        public ActionResult Create(Product productRespond)
        {
            List<Category> categories = new List<Category>();
            HttpResponseMessage responseCategory = client.GetAsync(client.BaseAddress + "/CategoryAPI").Result;
            string dataCategory = responseCategory.Content.ReadAsStringAsync().Result;
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            categories = JsonSerializer.Deserialize<List<Category>>(dataCategory, options);
            ViewBag.Categories = categories;
            return View(productRespond);
        }
        [HttpPost]
        public ActionResult CreateProduct(Product productRespond)
        {
            string data = JsonSerializer.Serialize(productRespond);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage responses = client.PostAsync(client.BaseAddress+ "/ProductsAPI", content).Result;
            if (responses.IsSuccessStatusCode)
            {
                ViewData["Mess"] = "Create success!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }













    }
}
