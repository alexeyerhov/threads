using System.IO;

namespace threads
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /* Объедините две предыдущих работы (практические работы 2 и 3): поиск файла и поиск текста в файле написав утилиту которая ищет файлы определенного расширения с указанным текстом. Рекурсивно. Пример вызова утилиты: utility.exe txt текст. */

            FindFile(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "*.txt");

            //foreach (var s in files) Console.WriteLine(s);

            Console.ReadKey();

        }
        
        public static void FindFile(string directory, string fileExpansion)
        {
            string[] dirs = Directory.GetDirectories(directory);

            var fileContain = Directory.GetFiles(directory, fileExpansion);
            foreach (var file in fileContain)
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    while (!sr.EndOfStream)
                    {
                        string value = sr.ReadLine();
                        if (value.Contains("someWord"))
                        {
                            Console.WriteLine(file);
                        }
                    }
                }
                
            }
            //files.AddRange(Directory.GetFiles(directory, fileExpansion));



            foreach (var dir in dirs)
            {
                FindFile(dir, fileExpansion); 
            }
        }
        
    }   
}