using DemoStoreApp.Models;

namespace DemoStoreApp.Interface
{
    public interface ICategory
    {
        IEnumerable<DTO_Category> List();
        Task Insert(DTO_Category sender);

        Task Delete(int id);
    }
}
