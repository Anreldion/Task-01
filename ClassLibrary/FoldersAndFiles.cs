using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
namespace ClassLibrary
{
    /// <summary>
    /// Работа с папками и файлами
    /// </summary>
    class FoldersAndFiles
    {
        /// <summary>
        /// Создать папку, если не существует
        /// </summary>
        /// <param name="path">Путь по которому будет создана папка</param>
        /// <returns></returns>
        public bool CreateFolder(string path)
        {
            if (!Directory.Exists(path))//Проверяем, не создан ли данный путь в предыдущие запуски программы.
            {
                try//Путь пока не создан... 
                {
                    Directory.CreateDirectory(path); //Пытаемся создать папку:
                }
                catch (IOException ex)
                {
                    //В случае ошибок ввода-вывода выдаем сообщение об ошибке
                    throw ex;
                }
                catch (UnauthorizedAccessException ex)
                {
                    //В случае ошибки с нехваткой прав вновь выдаем сообщение:
                    throw ex;
                }
            }
            return true;
        }
        /// <summary>
        /// Открыть документ содержащий описание производства.
        /// </summary>
        /// <param name="path"> Путь к файлу </param>
        /// <returns>Возвращает содержимое файла в виде строки</returns>
        string OpenFile(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    return sr.ReadToEnd().ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "";
            }

        }
        /// <summary>
        /// Сохранить строку как тектовый документ
        /// </summary>
        /// <param name="text">Данные</param>
        /// <param name="path">Путь для сохранения</param>
        void SaveFile(string text, string path)
        {
            StreamWriter sw = new StreamWriter(path);
            sw.Write(text);
            sw.Close();
        }
    }
}
