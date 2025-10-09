using System.ComponentModel.DataAnnotations;

namespace DemoStoreApp.CustomAttributes
{
    public class FirstLetterAttribute:ValidationAttribute
    {
        private readonly string mPrefix = "";
        public FirstLetterAttribute(string pr)
        { 
            this.mPrefix = pr;
        }

        public override bool IsValid(object? value)
        {
            bool result = false;
            if (value != null)
            {
                string k = value as string;
                result = k.ToUpperInvariant().StartsWith(this.mPrefix.ToUpperInvariant());
            }
            return result;
        }
    }
}
