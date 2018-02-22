using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            //initalize an empty list to hold my cheeses
            List<string> cheeses = new List<string>();
            //add some test cheeses to the list to pass into the view bag
            cheeses.Add("Gouda");
            cheeses.Add("Cheddar");
            cheeses.Add("Brie");
            cheeses.Add("Munster");
            ViewBag.cheeses = cheeses;
            return View();
        }
    }
}
