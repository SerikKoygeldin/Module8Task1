using System;
using System.IO;
using System.Runtime;
using System.Runtime.ConstrainedExecution;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Module8Work1
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            ClearDirectoryByTime();
        }

        static void ClearDirectoryByTime()
        {
            string dirName = @"C:\\CSharp";
            TimeSpan interval = TimeSpan.FromMinutes(30);

            if (Directory.Exists(dirName)) // Проверим, что директория существует
            {
                try
                {
                    string[] dirs = Directory.GetDirectories(dirName);
                    foreach (string dir in dirs)
                    {
                        DateTime dt = Directory.GetLastWriteTime(dir);
                        TimeSpan difference = DateTime.Now - dt;

                        if (difference > interval)
                        {
                            DirectoryInfo dirInfo = new DirectoryInfo(dir);
                            dirInfo.Delete(true); // Удаление со всем содержимым
                            Console.WriteLine("Каталог удален " + dir);
                        }
                    }

                    string[] files = Directory.GetFiles(dirName);
                    foreach (string file in files)
                    {
                        DateTime dt = File.GetLastWriteTime(file);
                        TimeSpan difference = DateTime.Now - dt;

                        if (difference > interval)
                        {
                            File.Delete(file);
                            Console.WriteLine("Файл удален " + file);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else 
            {
                Console.WriteLine("Каталог "+ dirName+ " не существует!");
            }
        }
    }
}
