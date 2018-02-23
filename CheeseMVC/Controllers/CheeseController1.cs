using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        //initalize a new empty list of dictionaries for the cheeses that will be dynamically added 
        static private Dictionary<string, string> Cheeses = new Dictionary<string, string>();

        //class property names are always capatilized 


        // GET: /<controller>/
        public IActionResult Index() //home page showing list of cheeses that have been added
        {

            ViewBag.cheeses = Cheeses;

            return View();
        }

        public IActionResult Add() //action method that routes to the add cheese form 
        {

            return View();
        }

        [HttpPost]
        [Route("/Cheese/Add")] // route attribute adds the NewCheese action method to the same action method as the add form 
        public IActionResult NewCheese(string name, string description) //parameter accepting cheese form input
        {
            //takes cheeses that were passed in from form post req and adds it to class property cheese list 
            Cheeses.Add(name, description);

            
            ViewBag.cheeses = Cheeses;
            //adds the list to the viewbag to be passed to the redirected Index view for iteration into li tags

            return Redirect("/Cheese"); //redirects back to the home page showing the list of cheeses
        }
    }
}
