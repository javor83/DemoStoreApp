using DemoStoreApp.Interface;
using DemoStoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoStoreApp.Controllers
{
    public class ProductController : Controller
    {
        private IProduct _product = null;
        private ICategory _category = null;
        //********************************************************************************
        public ProductController(IProduct p, ICategory category)
        {
            this._product = p;
            this._category = category;
        }
        //********************************************************************************
        public IActionResult Index()
        {

            return View(this._product.List());
        }
        //********************************************************************************
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int productid)
        {
            this._product.Delete(productid);
            return RedirectToAction("Index", "Product");
        }


        //********************************************************************************

        public IActionResult Insert()
        {
            DTO_Product_Insert new_product = DTO_Product_Insert.Empty();
            ViewBag.category = this._category.List();
            return View(new_product);
        }
        //********************************************************************************
        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult Insert(DTO_Product_Insert sender)
        {
            ViewBag.category = this._category.List();
            if (ModelState.IsValid)
            {
                this._product.Insert(sender);
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View(sender);
            }

        }


        //********************************************************************************
    }
}
