using RestoreApp.Models;


namespace RestoreApp.Interface
{
    public interface ICategory
    {
        
        IEnumerable<DTO_Category> List();
        Task Insert(DTO_Category sender);

        Task Delete(int id);

        DTO_Category Extract(int id);


        Task Edit(DTO_Category sender);
    }
}
