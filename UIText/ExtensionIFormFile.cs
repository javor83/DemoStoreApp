using Microsoft.AspNetCore.Http;

namespace RestoreApp.UIText
{
    public static class ExtensionIFormFile
    {
        public static string SaveStream(this IFormFile sender, string save_to_folder)
        {


            string ext_name = Path.GetExtension(sender.FileName);//.jpg
            string result = $"{Guid.NewGuid().ToString()}{ext_name}";

            var copy_to_file = $"{save_to_folder}/{result}";

            using (var save_stream = File.OpenWrite(copy_to_file))
            {
                sender.CopyTo(save_stream);
            }

            return result;
        }
    }
}
