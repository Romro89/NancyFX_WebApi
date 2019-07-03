using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NancyFX_WebApi.Models;

namespace NancyFX_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoriesController : Controller
    {

        public static List<Category> Categories = new List<Category>
        {
            new Category {Id = 1, Name = "Categoria 1"},
            new Category {Id = 2, Name = "Categoria 2"}
        };

        [HttpGet]

        public ActionResult<IEnumerable<Category>> Get()
        {
            return Categories;
        }

        [HttpGet("id")]
        public ActionResult<Category> Get(int id)
        {
            var categoria = new Category();

            foreach (var item in Categories)
            {
                if (item.Id == id)
                {
                    categoria = item;
                }
            }

            return categoria;

        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] Category cat)
        {
            var respuesta = string.Empty;

            Categories.Add(cat);
            return "Recibi respuesta";

        }

    }
}