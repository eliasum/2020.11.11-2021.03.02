using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SplittingString
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            // путь к файлу списка пользователей
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"files\person.txt");

            // считывание файла в строку
            string text = File.ReadAllText(path, Encoding.UTF8);

            // заполнение массива подстроками, разделенными символом новой строки
            string[] words = text.Split(new char[] { '\n' });

            // последовательный вывод элементов массива words
            foreach (string s in words)
            {
                Console.WriteLine(s);
            }

            //File.WriteAllLines(@"files\person_.txt", words);

            using (StreamWriter writer = new StreamWriter(@"files\person_.txt"))
            {
                foreach (string str in words)
                {
                    writer.WriteLine(str);
                }
            }
            */

            // путь к считываемому файлу списка пользователей
            string pathFileRead = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"files\person.txt");

            // путь к записываемому файлу списка пользователей
            string pathFileWrite = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"files\person_.txt");

            if (File.Exists(pathFileRead))
            {
                // Читаем файл с жесткого диска.
                string[] file = File.ReadAllLines(pathFileRead);

                // последовательный вывод элементов массива words
                foreach (string s in file)
                {
                    Console.WriteLine(s);
                }

                // список
                List<string> list = new List<string>(file);

                // Удаляем пустые строки
                list.RemoveAll(x => x == string.Empty);

                // Перезаписываем файл
                File.WriteAllLines(pathFileWrite, list);

            }
            else
            {
                Console.WriteLine("Error!");
            }

            Console.ReadKey();
        }
    }
}
