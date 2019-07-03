using Nancy;
using Nancy.Extensions;
using Nancy.IO;
using NancyFX_WebApi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NancyFX_WebApi.Controllers
{

    public class ProductController : NancyModule
    {

        public static List<Product> Products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Papas",
                Price = 15
            }
        };

        public ProductController()
        {

            Get("/", _ => "Hello Nancy");
            
            Get("/products/name/{name}", parameters => {
                return "Hello " + parameters.name;
            });

            Get("/products", _ => {
                return Products;
            });

            Post("/products", product =>
            {

                var text = RequestStream.FromStream(Request.Body).AsString();
                var newProduct = JsonConvert.DeserializeObject<Product>(text);

                Products.Add(newProduct);

                return "Exito";

            });
        }
    }

}