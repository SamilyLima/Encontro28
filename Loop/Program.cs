using System;

namespace Loop
{
    class Program
    {
        static void Main(string[] args)
        {
            int contar = 0;
            while (contar < 10)
            {
                contar++;
                if (contar % 2 == 0)
                {
                    // par
                    Console.WriteLine(contar);
                    Console.WriteLine("Este número é Par");
                }
                else
                {
                    //ÍMPAR  
                    Console.WriteLine(contar);
                    Console.WriteLine("Este número é ímpar");
                }
            }
            Console.WriteLine("Hello World!");
        }
    }
}
