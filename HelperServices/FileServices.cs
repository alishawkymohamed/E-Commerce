using IHelperServices;
using Microsoft.Extensions.Options;
using Models.DTOs;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace HelperServices
{
    public class FileServices : _HelperService, IFileServices
    {
        private readonly AppSettings _AppSettings;
        private readonly string _RootPath;

        public FileServices(IOptions<AppSettings> appSettings)
        {
            _AppSettings = appSettings.Value;
            _RootPath = _AppSettings.FileSettings.RelativeDirectory;
        }

        [DllImport(@"urlmon.dll", CharSet = CharSet.Unicode)]
        private static extern uint FindMimeFromData(
            uint pBC,
            [MarshalAs(UnmanagedType.LPStr)] string pwzUrl,
            [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
            uint cbSize,
            [MarshalAs(UnmanagedType.LPStr)] string pwzMimeProposed,
            uint dwMimeFlags,
            out uint ppwzMimeOut,
            uint dwReserverd
        );

        public string GetFileMimeType(byte[] content)
        {
            try
            {
                FindMimeFromData(0, null, content, 256, null, 0, out uint mimeType, 0);

                IntPtr mimePointer = new IntPtr(mimeType);
                string mime = Marshal.PtrToStringUni(mimePointer);
                Marshal.FreeCoTaskMem(mimePointer);

                return mime ?? "application/octet-stream";
            }
            catch
            {
                return "application/octet-stream";
            }
        }

        public void SaveFile(string fileName, byte[] content)
        {
            //var subDirectory = fileName.Substring(0, 2);
            DirectoryInfo directory = Directory.CreateDirectory(_RootPath); // Directory.CreateDirectory(Path.Combine(_RootPath, subDirectory));
            File.WriteAllBytes(Path.Combine(directory.FullName, fileName), content);
        }

        public byte[] GetFileContent(string fileName)
        {
            //var subDirectory = fileName.Substring(0, 2);
            string subDirectoryFullPath = _RootPath;// Path.Combine(_RootPath, subDirectory);
            string[] filePaths = Directory.GetFiles(subDirectoryFullPath, fileName + ".*");
            if (filePaths != null && filePaths.Length > 0)
            {
                return File.ReadAllBytes(filePaths[0]);
            }
            else
            {
                return new byte[] { };
            }
        }

        public void DeleteFile(string fileName)
        {
            //var subDirectory = fileName.Substring(0, 2);
            string subDirectoryFullPath = _RootPath;// Path.Combine(_RootPath, subDirectory);
            File.Delete(Path.Combine(subDirectoryFullPath, fileName));
        }

        public void DeleteFiles(string searchPattern)
        {
            //var subDirectory = fileName.Substring(0, 2);
            string subDirectoryFullPath = _RootPath;// Path.Combine(_RootPath, subDirectory);
            Directory.GetFiles(subDirectoryFullPath, searchPattern).AsParallel().ForAll(filePath =>
            {
                File.Delete(filePath);
            });
        }
    }
}