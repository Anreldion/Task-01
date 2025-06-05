using System;
using System.IO;
using ClassLibrary.Services.Interfaces;

namespace ClassLibrary.Services
{
    /// <summary>
    /// Service for working with folder. 
    /// </summary>
    public class FolderService : IFolderService
    {
        public DirectoryInfo CreateFolder(string path)
        {
            try
            {
                return Directory.CreateDirectory(path);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool IsExist(string path)
        {
            return Directory.Exists(path);
        }
    }
}
