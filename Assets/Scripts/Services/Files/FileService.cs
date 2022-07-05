using System.IO;

namespace Services.Files
{
    public class FileService : IFileService
    {
        public string FileToString(string path)
        {
            return File.ReadAllText(path);
        }

        public void StringToFile(string data, string path)
        {
            File.WriteAllText(path, data);
        }

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public void WriteFile(byte[] data, string path)
        {
            FileUtils.WriteAllBytes(path, data);
        }

        public byte[] ReadFile(string path)
        {
            return FileUtils.ReadAllBytes(path);
        }
    }
}