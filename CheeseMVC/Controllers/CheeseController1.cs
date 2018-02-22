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
        //initalize a new empty list for the cheeses that will be dynamically added 
        static private List<string> Cheeses = new List<string>();


        // GET: /<controller>/
        public IActionResult Index()
        {

            ViewBag.cheeses = Cheeses;
           
            return View();
        }

        public IActionResult Add()
        {

            return View();
        }


        public IActionResult NewCheese(string name)
        {


            return Redirect("Index");
        }
    }
}
