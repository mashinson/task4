using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrangedArray
{
    class Program
    {
        static void NewArray(int[] array, int k)
        {
            int poz = 0;
            if (k == array.Length - 1)
            {
                return;
            }

            if (array[k] > 0)
            {
                poz = array[k];

                for (int j = k; j > 0; j--)
                {
                    array[j] = array[j - 1];
                }

                array[0] = poz;

            }
            k++;
            NewArray(array, k);
        }


        static void Main(string[] args)
        {
            Console.Write("Введите количество чисел: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[n];


            Console.WriteLine("Введите диапозон чисел: ");
            int st = Convert.ToInt32(Console.ReadLine());
            int end = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            // Заполняем рандомными числами 
            Random x = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = x.Next(st, end);
                Console.Write("{0} ", array[i]);
            }

            int k = 1;
            NewArray(array, k);

            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.ReadKey();
        }
    }
}
