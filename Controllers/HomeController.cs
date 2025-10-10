
using DemoStoreApp.Interface;
using DemoStoreApp.Models;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        
      
        //**************************************************************************
        public HomeController()
        {
           
            
        }
        //**************************************************************************
        public IActionResult Index()
        {
            return View();
        }

        

        //**************************************************************************
    }
}
