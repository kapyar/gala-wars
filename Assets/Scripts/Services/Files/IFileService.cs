namespace Services.Files
{
    public interface IFileService
    {
        string FileToString(string path);
        void StringToFile(string data, string path);
        bool FileExists(string path);

        void WriteFile(byte[] data, string path);
        byte[] ReadFile(string path);
    }
}