using Microsoft.AspNetCore.Mvc;

namespace DemoStoreApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Insert()
        {
            return Json("");
        }
    }
}
