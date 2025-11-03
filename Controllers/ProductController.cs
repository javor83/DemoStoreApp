using RestoreApp.Interface;
using RestoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace RestoreApp.Controllers
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

        public IActionResult Insert()
        {
            DTO_Product_Insert new_product = DTO_Product_Insert.Empty();
            ViewBag.category = this._category.List();
            return View(new_product);
        }
        //********************************************************************************
        public IActionResult Edit(int? product_id)
        {
            bool find_product = this._product.FindByID(product_id);
            if(find_product)
            {

                ViewBag.image_preview = new DTO_Product_Edit_ViewBag()
                {
                    ListCategory = this._category.List(),
                    UploadedImages = this._product.Preview(product_id)
                };

                return Json(ViewBag.image_preview);
            }
            else
                return NotFound("no product");
        }


        //********************************************************************************
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int productid)
        {
            this._product.Delete(productid);
            return RedirectToAction("Index", "Product");
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
