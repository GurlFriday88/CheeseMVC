using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
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

        public IActionResult Delete()// action method tht shows form to delete cheese
        {
            ViewBag.cheeses = Cheeses;

            return View();
        } 


        [HttpPost]
        [Route("/Cheese/Add")] // route attribute adds the NewCheese action method to the same action method as the add form 
        public IActionResult NewCheese(string name, string description) //parameter accepting cheese form input
        {   //create variable to hold error message
            string Error;
            //make regex variable that will check for presence of alphabetic characters and spaces
            var regexItem = new Regex("^[a-zA-Z ]*$");

            //conditional that checks for presence of string input
            if (name != null) //if there is input present check to make sure it does not contain special characters
            {
                if (regexItem.IsMatch(name) == false) //if input contains special characters or numbers then throw and error and redirect user back to add form.
                {
                    Error = "Cheeses can only contain characters and spaces";

                    ViewBag.error = Error;

                    return View("Add");

                }

                else // if input passes valiation add the name and description to the dictionary
                {
                    Cheeses.Add(name, description);

                    ViewBag.cheeses = Cheeses;
                    //adds the list to the viewbag to be passed to the redirected Index view for iteration into li tags

                    return Redirect("/Cheese"); //redirects back to the home page showing the list of cheeses

                }

            }
            else //if there is no input generate error message and add that message to the viewbag. Redirect user back to the add form 
            {
                Error = "Please enter the name of a cheese";
                ViewBag.error = Error;
                return View("Add");



            }



        }

        [HttpPost]
        [Route("/Cheese/Delete")]
        public IActionResult DeleteCheese(string cheese)
        {
            string ConfirmationMessage;

            if (Cheeses.ContainsKey(cheese))
            {
                Cheeses.Remove(cheese);
                ConfirmationMessage = "Selection has been successfuly deleted";

            }
            else
            {

               ConfirmationMessage = "Please select a cheese to delete";

            }

            
            TempData["ConfirmationMessage"] = ConfirmationMessage; //using tempdata to access messages in view because viewbags become null on redirects. 
            return Redirect("/Cheese");
        }

    }
}
