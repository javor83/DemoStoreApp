namespace RestoreApp.Models
{
    public class DTO_Product_Edit_ViewBag
    {
        public IEnumerable<DTO_Category> ListCategory { get; set; }
        public IEnumerable<DTO_ProductImage> UploadedImages { get; set; }
    }
}
