using System;

namespace aaaaaa
{
    class Program
    {
        static void Main(string[] args)
        {

            double x = (float)Convert.ToDouble(Console.ReadLine());
            double y = (float)Convert.ToDouble(Console.ReadLine());
            double z = (x + y) / 2;
            Console.WriteLine("MEDIA = {0:F5}", z);
            Console.ReadLine();
        }
    }
}
