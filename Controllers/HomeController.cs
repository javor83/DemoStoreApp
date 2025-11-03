
//using RestoreApp.Interface;
using RestoreApp.Models;
using Microsoft.AspNetCore.Mvc;


namespace RestoreApp.Controllers
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
