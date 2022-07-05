using System.IO;
using File = System.IO.File; 

namespace Services.Files
{
    public static class FileUtils
    {
        public static void WriteAllBytes(string path, byte[] data)
        {
            using (Stream stream = File.Create(path, 4096))
            {
                stream.Write(data, 0, data.Length);
            }
        }

        public static byte[] ReadAllBytes(string path)
        {
            return File.ReadAllBytes(path);
        }
    }
}