using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Min
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество чисел: ");
            int n = Convert.ToInt32(Console.ReadLine());

            double[] array = new double[n];


            Console.WriteLine("Введите диапозон чисел: ");
            double st = Convert.ToDouble(Console.ReadLine());
            double end = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();

            // Заполняем рандомными числами 
            Random x = new Random();
            int epsilon = 10;
            for (int i = 0; i < n; i++)
            {
                array[i] = ((double)x.Next(Convert.ToInt32(st * epsilon), Convert.ToInt32(end * epsilon))) / epsilon;
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
            Console.WriteLine();

            // Находим min и max
            double max = array[0],
                   min = array[0];
            int kmax = 0,
                kmin = 0;
            for (int i = 1; i < n; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                    kmin = i;
                }
                if (array[i] > max)
                {
                    max = array[i];
                    kmax = i;
                }
            }

            Console.WriteLine("Max = {0}", array[kmax]);
            Console.WriteLine("Min = {0}", array[kmin]);
            Console.WriteLine();

            // Меняем min и max местами
            double temp = 0;
            temp = array[kmin];
            array[kmin] = array[kmax];
            array[kmax] = temp;

            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", array[i]);
            }

            Console.ReadLine();
        }
    }
}
