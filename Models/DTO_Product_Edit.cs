using RestoreApp.CustomAttributes;
using RestoreApp.UIText;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RestoreApp.Models
{
   

    

    public class DTO_Product_Edit
    {
        //кой продукт ще редактираме, скрито поле
        public int ProductId { get; set; }
        //*********************************************************************
        //кое изображение на продукта ще редактираме, скрито поле
        public int ImageID { get; set; }
        //*********************************************************************
        //все пак  да видим файла в img src
        public string ImageName { get; set; }
        //*********************************************************************
        [Required(ErrorMessage = resx_DTO_Product.Required_Name, AllowEmptyStrings = false)]
        [DisplayName(resx_DTO_Product.Display_Name)]
        [FirstLetter(ErrorMessage = resx_DTO_Product.FirstLetter_Name)]
        public string? Name { get; set; }
        //*********************************************************************
        [Required(ErrorMessage = resx_DTO_Product.Required_Description, AllowEmptyStrings = false)]
        [DisplayName(resx_DTO_Product.Display_Description)]
        public string? Description { get; set; }
        //*********************************************************************
        [Required(ErrorMessage = resx_DTO_Product.Required_Price, AllowEmptyStrings = false)]
        [DisplayName(resx_DTO_Product.Display_Price)]
        [Range(const_price.Min, const_price.Max, ErrorMessage = resx_DTO_Product.Range_Error)]

        public decimal? Price { get; set; }
        //*********************************************************************

        [Required(ErrorMessage = resx_DTO_Product.Required_Category)]
        [DisplayName(resx_DTO_Product.Display_Category)]
        public int? CategoryID { get; set; }
        //*********************************************************************

        //кое ще е новото изображение, не е задължително да качваме
        [DisplayName(resx_DTO_Product.Display_PreviewUpload)]
        public IFormFile? ListPreview { get; set; }

        //*********************************************************************
    }
}
