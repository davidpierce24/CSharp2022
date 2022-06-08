using Microsoft.AspNetCore.Mvc;  //This is a service that brings in our MVC functionality
namespace webProject1.Controllers;     //be sure to use your own project's namespace!
    public class HelloController : Controller   //remember inheritance??
    {
        //for each route this controller is to handle:
        [HttpGet]       //type of request
        [Route("")]     //associated route string (exclude the leading /)
        public ViewResult Index()
        {
            return View("Index");
        }

        [HttpGet("second")]
        public ViewResult Second()
        // if this action name "Second" is exact same as html name "Second" that we're trying to render, then we can actually leave the View in the return blank
        {
            return View();
        }

        [HttpGet("third/{name}")]
        public ViewResult NameRoute(string name)
        {
            ViewBag.Name = name;
            ViewBag.MyArray = new int[5] {1,2,3,4,5};
            return View("Third");
        }
    }