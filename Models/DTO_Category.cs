using DemoStoreApp.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace DemoStoreApp.Models
{
    public class DTO_Category
    {
        [Required(AllowEmptyStrings =false,ErrorMessage ="Категорията е задължителна")]
        
        [StringLength(50,MinimumLength =5,ErrorMessage ="Дължината е между 5 и 50 знака")]
        [Display(Name = "Име на категория продукти")]
        [FirstLetter("ABC",ErrorMessage ="Започва с ABC !")]
        public string? CategoryName { get; set; }

        public int? CategoryID { get; set; }

    }
}
