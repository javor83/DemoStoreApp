using RestoreApp.Models;

namespace RestoreApp.Interface
{
    public interface IProduct
    {
        void Insert(DTO_Product_Insert sender);

        IEnumerable<DTO_Product_Select> List();

        void Delete(int id);

        bool FindByID(int? id);

        IEnumerable<DTO_ProductImage> Preview(int? id);


        DTO_Product_Edit SelectedProduct(int? id);
    }


}
