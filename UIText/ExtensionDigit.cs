using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;


namespace RestoreApp.UIText
{
    public static class ExtensionDigit
    {
        public static string Money(this decimal? sender)
        {
            return $"{sender:C2}";
        }

        public static string Money(this decimal sender)
        {
            return $"{sender:C2}";
        }
    }

   
        


   
}
