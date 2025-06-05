using ClassLibrary.Services.Interfaces;
using System;
using System.IO;

namespace ClassLibrary.Services
{
    public class FileService : IFileService
    {
        public void SaveFile(string text, string path)
        {
            var sw = new StreamWriter(path);
            sw.Write(text);
            sw.Close();
        }

        public string OpenFile(string path)
        {
            try
            {
                using var sr = new StreamReader(path);
                return sr.ReadToEnd();
            }
            catch (Exception e)
            {
                throw; 
            }
        }
    }
}
