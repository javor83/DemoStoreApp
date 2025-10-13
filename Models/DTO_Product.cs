using System.ComponentModel.DataAnnotations;
using UIText;

namespace DemoStoreApp.Models
{
    public class DTO_Product
    {
        

        public int? ID { get; set; }
        //********************************************************************************
        [Required(ErrorMessage = resx_DTO_Product.Required_Name,AllowEmptyStrings = false)]
        [Display(Name =resx_DTO_Product.Display_Name)]
        public string? Name { get; set; }
        //********************************************************************************
        [Required(ErrorMessage = resx_DTO_Product.Required_Description, AllowEmptyStrings = false)]
        [Display(Name = resx_DTO_Product.Display_Description)]
        public string? Description { get; set; }
        //********************************************************************************
        [Required(ErrorMessage = resx_DTO_Product.Required_Price, AllowEmptyStrings = false)]
        [Display(Name = resx_DTO_Product.Display_Price)]
        public decimal? Price { get; set; }
        //********************************************************************************
        [Required(ErrorMessage = resx_DTO_Product.Required_Category, AllowEmptyStrings = false)]
        [Display(Name = resx_DTO_Product.Display_Category)]
        public int? Category { get; set; } //коя категория е избрана
        //********************************************************************************
        public IEnumerable<DTO_Category> AvailableCategory { get; set; }//от кои категории избираме
        //********************************************************************************
        [Required(ErrorMessage = resx_DTO_Product.Required_PreviewUpload, AllowEmptyStrings = false)]
        [Display(Name = resx_DTO_Product.Display_PreviewUpload)]
        public IFormFile PreviewUpload { get; set; }
        //********************************************************************************
    }
}
