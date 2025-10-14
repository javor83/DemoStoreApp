using DemoStoreApp.Interface;
using DemoStoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoStoreApp.Controllers
{
    public class ProductController : Controller
    {
        private IProduct _product = null;
        //********************************************************************************
        public ProductController(IProduct p)
        {
            this._product = p;
        }
        //********************************************************************************
        public IActionResult Index()
        {

            return View(this._product.List());
        }
        
       
        //********************************************************************************
    }
}
