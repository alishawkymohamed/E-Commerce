namespace IHelperServices
{
    public interface IFileServices : _IHelperService
    {
        string GetFileMimeType(byte[] content);

        string SaveFile(string fileName, string extension, byte[] content);

        string SaveFile(string fileName, string extension, string base64);

        byte[] GetFileContent(string fileName);

        void DeleteFile(string fileName);

        void DeleteFiles(string searchPattern);
    }
}