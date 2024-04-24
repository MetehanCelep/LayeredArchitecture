using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities.Concrete;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public List<Product> Get()
        {
            return new List<Product>
        {
            new Product{ProductId = 1,ProductName="Elma"},
            new Product{ProductId = 2,ProductName="Armut"},
        };
        }
    }
}
