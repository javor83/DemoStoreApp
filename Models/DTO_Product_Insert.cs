using RestoreApp.CustomAttributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RestoreApp.UIText;

namespace RestoreApp.Models
{

    




    public class DTO_Product_Insert
    {
        [Required(ErrorMessage = resx_DTO_Product.Required_Name,AllowEmptyStrings = false)]
        [DisplayName(resx_DTO_Product.Display_Name)]
        [FirstLetter(ErrorMessage = resx_DTO_Product.FirstLetter_Name)]
        public string? Name { get; set;}

        //*********************************************************************
        [Required(ErrorMessage = resx_DTO_Product.Required_Description, AllowEmptyStrings = false)]
        [DisplayName(resx_DTO_Product.Display_Description)]
        public string? Description { get; set;}
        //*********************************************************************
        [Required(ErrorMessage = resx_DTO_Product.Required_Price, AllowEmptyStrings = false)]
        [DisplayName(resx_DTO_Product.Display_Price)]
        [Range(const_price.Min,const_price.Max,ErrorMessage =resx_DTO_Product.Range_Error)]
        
        public decimal? Price { get; set; }
        //*********************************************************************
        [Required(ErrorMessage = resx_DTO_Product.Required_Category)]
        [DisplayName(resx_DTO_Product.Display_Category)]
        public int? CategoryID { get; set; }
        //*********************************************************************
        [Required(ErrorMessage = resx_DTO_Product.Required_PreviewUpload)]
        [DisplayName(resx_DTO_Product.Display_PreviewUpload)]
        public IEnumerable<IFormFile>? ListPreview { get; set; }
        //*********************************************************************


        public static DTO_Product_Insert Empty()
        {
            DTO_Product_Insert result = new DTO_Product_Insert()
            {
                Name = string.Empty,
                Description = string.Empty,
                Price = null,
                CategoryID = null,
                ListPreview = null
            };
            return result;

        }
        //*********************************************************************

    }
}
