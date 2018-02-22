﻿using System;
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
        public IActionResult Index() //home page showing list of cheeses that have been added
        {

            ViewBag.cheeses = Cheeses;
           
            return View();
        }

        public IActionResult Add() //action method that routes to the add cheese form 
        {

            return View();
        }


        public IActionResult NewCheese(string name) //parameter accepting cheese form input
        {
            //takes cheeses that were passed in from form post req and adds it to class property cheese list 
            Cheeses.Add(name);

            ViewBag.cheeses = Cheeses;
            //adds the list to the viewbag to be passed to the redirected Index view for iteration into li tags

            return Redirect("Index");
        }
    }
}
