namespace IHelperServices
{
    public interface IFileServices : _IHelperService
    {
        string GetFileMimeType(byte[] content);

        void SaveFile(string fileName, byte[] content);

        byte[] GetFileContent(string fileName);

        void DeleteFile(string fileName);

        void DeleteFiles(string searchPattern);
    }
}