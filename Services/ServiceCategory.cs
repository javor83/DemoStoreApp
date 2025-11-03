
using RestoreApp.Interface;
using RestoreApp.LocalDbStore;
using RestoreApp.Models;

namespace RestoreApp.Services
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
        async Task ICategory.Delete(int id)
        {
            var ct = this._context.Categories.Where(x => x.Id == id);
            if (ct.Any())
            {
                this._context.Categories.Remove(ct.First());
                await this._context.SaveChangesAsync();
            }
        }
        //**************************************************************************
        DTO_Category ICategory.Extract(int id)
        {
            DTO_Category result = null;
            var ct = this._context.Categories.Where(x => x.Id == id);
            if (ct.Any())
            {
                var first = ct.First();
                result = new DTO_Category()
                {
                    CategoryID = first.Id,
                    CategoryName = first.Cname
                };
            }


            return result;
        }

        //**************************************************************************
        async Task ICategory.Edit(DTO_Category sender)
        {
            var ct = this._context.Categories.Where(x => x.Id == sender.CategoryID).FirstOrDefault();
            if (ct!=null)
            {
                ct.Cname = sender.CategoryName;
                
                await this._context.SaveChangesAsync();
            }
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
            var result = this._context.Categories.OrderBy(x => x.Cname).Select
                        (
                        x => new DTO_Category()
                        {
                            CategoryID = x.Id,
                            CategoryName = x.Cname
                        }

                        );
                       
            return result;


        }
        //**************************************************************************
    }
}
