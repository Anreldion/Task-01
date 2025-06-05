using System.IO;

namespace ClassLibrary.Services.Interfaces
{
    internal interface IFileService
    {
        void SaveFile(string text, string path);
        string OpenFile(string path);
    }
}
