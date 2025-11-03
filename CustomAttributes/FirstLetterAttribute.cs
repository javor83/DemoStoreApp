using System.ComponentModel.DataAnnotations;

namespace RestoreApp.CustomAttributes
{
    public class FirstLetterAttribute:ValidationAttribute
    {
       
        public FirstLetterAttribute()
        { 
          
        }

        public override bool IsValid(object? value)
        {
            bool result = false;
            if (value != null)
            {
                string k = value as string;
                if (k.Length > 0)
                {
                    result = Char.IsUpper(k[0]);
                }
                //result = k.ToUpperInvariant().StartsWith(this.mPrefix.ToUpperInvariant());
            }
            return result;
        }
    }
}
