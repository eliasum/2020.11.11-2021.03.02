using System;

namespace InterpolatingStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                /*
                Для использования интерполяции строк необходимо перед строкой указывать символ доллара — "$".
                При интерполяции строки указано непосредственно значение в {}, которое необходимо подставить в строку.
                */
                Console.WriteLine($@"серега 
таксист антибухер :) {Convert.ToString(i)}
");
            }

            Console.ReadKey();
        }
    }
}
