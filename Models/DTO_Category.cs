using RestoreApp.CustomAttributes;
using System.ComponentModel.DataAnnotations;
using RestoreApp.UIText;

namespace RestoreApp.Models
{
    

    public class DTO_Category
    {

        
        [Required(AllowEmptyStrings =false,ErrorMessage =resx_DTO_Category.Required_CategoryName)]
        
        [StringLength(50,MinimumLength =5,ErrorMessage = resx_DTO_Category.StringLength_CategoryName)]
        [Display(Name = resx_DTO_Category.Display_CategoryName)]
        [FirstLetter(ErrorMessage = resx_DTO_Category.FirstLetter_CategoryName)]
        public string? CategoryName { get; set; }

       
        public int? CategoryID { get; set; }

    }
}
