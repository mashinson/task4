using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Towers
{
    class Program
    {
        static void Tov(int start, int middle, int end, int n)
        {
            if (n == 0)
            {
                return;
            }
            Tov(start, end, middle, n - 1);
            Console.WriteLine("{0} -> {1}", start, end);
            Tov(middle, start, end, n - 1);

        }
        static void Main(string[] args)
        {

            Console.Write("Введите количество дисков: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("С какой палки переставлять: ");
            int st = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("На какую: ");
            int end = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine();

            int k2 = 2;

            Tov(st, k2, end, n);
            Console.ReadKey();

        }
    }
}
