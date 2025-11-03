using RestoreApp.Interface;
using RestoreApp.Models;
using System.Text.Json;
using RestoreApp.UIText;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using RestoreApp.LocalDbStore;

namespace RestoreApp.Services
{
    public class ServiceProduct:IProduct
    {
        private SportsStoreContext _context = null;
        private Microsoft.AspNetCore.Hosting.IWebHostEnvironment Environment = null;
        //*************************************************
        public ServiceProduct(SportsStoreContext cn, IWebHostEnvironment environment)
        {
            this._context = cn;
            this.Environment = environment;
        }
        //*************************************************
        void IProduct.Delete(int id)
        {
            var product = this._context.Products.Where(x => x.Id == id).FirstOrDefault();
            if (product != null)
            {
                this._context.Products.Remove(product);
                this._context.SaveChanges();
            }
        }
        //*************************************************
        bool IProduct.FindByID(int? id)
        {
            bool result = false;
            if (id.HasValue)
            {
                result = this._context.Products.Any(x => x.Id == id.Value);
            }
            else

                result = false;
            return result;

        }
        //*************************************************
        IEnumerable<DTO_ProductImage> IProduct.Preview(int? id)
        {
            List<DTO_ProductImage> result = new List<DTO_ProductImage>();
            var query = this._context.Products.Where(x => x.Id == id.Value).Include(image_preview => image_preview.ProductPreviews);
            foreach (var k in query)
            {

                foreach (var preview in k.ProductPreviews)
                {

                    result.Add
                        (
                            new DTO_ProductImage()
                            {
                                Id = preview.Id,
                                Preview = preview.Preview

                            }
                        );
                }

            }
            return result;
        }

        //*************************************************
        DTO_Product_Edit IProduct.SelectedProduct(int? id)
        {
            DTO_Product_Edit result = new DTO_Product_Edit();
           
            
            return result;
        }

       

        //*************************************************
        void IProduct.Insert(DTO_Product_Insert sender)
        {
            string wwwroot = this.Environment.WebRootPath;
            Product db_product = new Product()
            {
                Pname = sender.Name.Trim(),
                Pdesc = sender.Description.Trim(),
                Price = sender.Price.Value,
                Pcategory = sender.CategoryID
            };
           
            foreach (var k in sender.ListPreview)
            {
                string bg = $"{wwwroot}/{const_button.preview_folder}";
                string save_as = k.SaveStream(bg);
                ProductPreview preview = new ProductPreview()
                {
                    Product = db_product,
                    Preview = save_as,
                    

                };
                this._context.ProductPreviews.Add(preview);

            }
            this._context.Products.Add(db_product);
            this._context.SaveChanges();
        }

        //*************************************************
        IEnumerable<DTO_Product_Select> IProduct.List()
        {

            var result = from product in this._context.Products
                         join ct in this._context.Categories

                         on product.Pcategory equals ct.Id 

                         join product_preview in this._context.ProductPreviews
                         on product.Id equals product_preview.ProductId into group_preview

                         
                         select new DTO_Product_Select()
                         {
                             ID = product.Id,
                             Price = Convert.ToDecimal(product.Price),
                             Name = product.Pname,
                             Description = product.Pdesc,
                             CategoryID = ct.Id,
                             CategoryName = ct.Cname,
                             Preview = group_preview.Select(x=>x.Preview)
                         };


            return result;

        }
        //*************************************************
    }
}


