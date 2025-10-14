using DemoStoreApp.Interface;
using DemoStoreApp.LocalDbStore;
using DemoStoreApp.Models;
using System.Text.Json;

namespace DemoStoreApp.Services
{
    public class ServiceProduct:IProduct
    {
        private SportsStoreContext _context = null;
        //*************************************************
        public ServiceProduct(SportsStoreContext cn)
        {
            this._context = cn;
        }
        //*************************************************
        public IEnumerable<DTO_Product_Select> List()
        {

            var result = from product in this._context.Products
                         join ct in this._context.Categories

                         on product.Pcategory equals ct.Id 

                         join product_preview in this._context.ProductPreviews
                         on product.Id equals product_preview.ProductId into group_preview

                         
                         select new DTO_Product_Select()
                         {
                             ID = product.Id,
                             Price = product.Price,
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


