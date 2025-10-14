using DemoStoreApp.Models;

namespace DemoStoreApp.Interface
{
    public interface IProduct
    {


        IEnumerable<DTO_Product_Select> List();
    }
}
