using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoreApp.UIText
{
    public static class ExtensionString
    {
        public static string ImgHTML(this string sender)
        {
            return $"/{const_button.preview_folder}/{sender}";
        }

       
    }
}
