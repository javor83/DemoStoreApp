using DemoStoreApp.db;
using DemoStoreApp.Interface;
using DemoStoreApp.Models;

namespace DemoStoreApp.Services
{
    public class ServiceCategory:ICategory
    {
        private SportsStoreContext _context = null;
        //**************************************************************************
        public ServiceCategory(SportsStoreContext cn)
        { 
            this._context = cn;
        }
        //**************************************************************************
        async Task ICategory.Insert(DTO_Category sender)
        {


            Category ct = new Category()
            {
                Cname = Convert.ToString(sender.CategoryName)
            };
            this._context.Categories.Add(ct);
            await this._context.SaveChangesAsync();

        }
        //**************************************************************************
        IEnumerable<DTO_Category> ICategory.List()
        {
            var query = from x in this._context.Categories
                        select new DTO_Category()
                        {
                            CategoryID = x.Id,
                            CategoryName = x.Cname
                        };
            return query;


        }
        //**************************************************************************
    }
}
