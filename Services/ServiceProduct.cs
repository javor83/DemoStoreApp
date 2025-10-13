using DemoStoreApp.db;
using DemoStoreApp.Interface;
using DemoStoreApp.Models;

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
        void IProduct.Insert(DTO_Product sender)
        {
            
        }
        //*************************************************
    }
}
