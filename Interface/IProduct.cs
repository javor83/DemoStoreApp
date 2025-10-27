using DemoStoreApp.Models;

namespace DemoStoreApp.Interface
{
    public interface IProduct
    {
        void Insert(DTO_Product_Insert sender);

        IEnumerable<DTO_Product_Select> List();

        void Delete(int id);
    }
}
