
using DemoStoreApp.Interface;
using DemoStoreApp.Models;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICategory cn = null;
        //**************************************************************************
        public HomeController(ILogger<HomeController> logger, ICategory category)
        {
            this.cn = category;
            _logger = logger;
        }
        //**************************************************************************
        public IActionResult Index()
        {
            return View(this.cn.List());
        }

        //**************************************************************************
        public IActionResult InsertCategory()
        {
            DTO_Category data = new DTO_Category()
            {
                CategoryName = "your category....",
                CategoryID = null

            };
            return View(data);
        }
        //**************************************************************************
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertCategory(DTO_Category sender)
        {
            if (ModelState.IsValid)
            {
                await this.cn.Insert(sender);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(sender);
            }

        }

        //**************************************************************************
    }
}
