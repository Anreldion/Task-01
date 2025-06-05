using System.IO;

namespace ClassLibrary.Services.Interfaces
{
    public interface IFolderService
    {
        public DirectoryInfo CreateFolder(string path);
        bool IsExist(string path);
    }
}
