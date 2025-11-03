using RestoreApp.Interface;
using RestoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RestoreApp.Controllers
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
        [HttpGet]
        public IActionResult Edit(int id)
        {
            DTO_Category local_data = this.cn.Extract(id);
            if (local_data != null)
            {
               
                    return View(local_data);
            }
            else
            {
                return NotFound();
            }
        }
        //**************************************************************************
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DTO_Category sender)
        {
            if (ModelState.IsValid)
            {
                await this.cn.Edit(sender);
                
                return RedirectToAction("Index", "Category");
            }
            else
                return View(sender);


        }
        //**************************************************************************
        [HttpGet]
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
