using System;

namespace tabuda
{
    internal class Program
    {
        private static bool Main(string[] args)
        {
            int numTabuada = Convert.ToInt16(Console.ReadLine());
            int linha = 1;
            while (linha <= 10)
            {
                var r = linha * numTabuada;
                Console.WriteLine(numTabuada + " x " + linha + " = " + r);
                linha = linha + 1;
            }
            }

    
        }
    }
}
