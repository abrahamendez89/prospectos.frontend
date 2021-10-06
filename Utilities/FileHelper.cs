using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class FileHelper
    {
        public static String FileToBase64String(String path)
        {
            System.IO.Stream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            return base64String;
        }
        public static String GetFileNameFromPath(String path)
        {
            return System.IO.Path.GetFileName(path); 
        }
    }
}
