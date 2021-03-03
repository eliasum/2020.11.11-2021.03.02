using System;

namespace ReplacingSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            // точная строка
            string c1 = @"серега 
таксист антибухер :) !
", c2 = "!", c3 = "";   // заменяемая и заменяющая подстроки

            for (int i = 0; i < 10; i++)
            {
                /*найти в строке с1 подстроку с2 и заменить на с3; с3 содержит переменную i, сконвертированную в строку*/
                Console.WriteLine(c1.Replace(c2, c3 + Convert.ToString(i)));
            }

            Console.ReadKey();
        }
    }
}
