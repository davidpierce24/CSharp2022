using Microsoft.AspNetCore.Mvc;  //This is a service that brings in our MVC functionality
namespace RazorFun.Controllers;     //be sure to use your own project's namespace!
    public class RazorController : Controller   //remember inheritance??
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            ViewBag.MyArray = new string[4] {"Apple Pie","Burritos","Clams Casino","Donuts"};
            return View("Index");
        }
    }