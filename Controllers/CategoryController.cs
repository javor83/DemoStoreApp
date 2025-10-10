using DemoStoreApp.Interface;
using DemoStoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoStoreApp.Controllers
{
    public class CategoryController : Controller
    {
        private ICategory cn = null;
        //**************************************************************************
        public CategoryController(ICategory category)
        {
            this.cn = category;
        }
        //**************************************************************************
        public IActionResult Index()
        {
            return View(this.cn.List());
        }
        //**************************************************************************
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Delete(int cid)
        {
            await this.cn.Delete(cid);
            return RedirectToAction("Index", "Category");

        }


        //**************************************************************************
        public IActionResult InsertCategory()
        {
            DTO_Category data = new DTO_Category()
            {
                CategoryName = string.Empty,
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
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View(sender);
            }

        }
        //**************************************************************************
    }
}
