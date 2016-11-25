using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correct_String
{
    class Program
    {
        static bool Cor(string[] strNew)
        {
            int ch1 = 0;
            int k1 = 0;
            int k2 = 0;
            bool br = false;
            char[] operations = new char[] { '/', '\\', '-', '+', '*' };


            for (int i = 0; i < strNew.Length; i++)
            {
                if (strNew[i] == "(")
                {
                    if (br == false)
                    {
                        br = true;
                        k1 = i;
                    }
                    ch1 += 1;
                }
                if (strNew[i] == ")")
                {
                    ch1 -= 1;
                    k2 = i;
                }


                if (ch1 == 0 && br)
                {
                    string[] a = new string[k2 - (k1 + 1)];
                    Array.Copy(strNew, k1 + 1, a, 0, k2 - (k1 + 1));
                    if (Cor(a))
                    {
                        if (k2 != strNew.Length - 1)
                        {
                            Array.Copy(strNew, k2 + 1, strNew, k1 + 1, strNew.Length - k2 - 1);
                        }
                        Array.Resize(ref strNew, strNew.Length - k2 + k1);
                        strNew[k1] = "0";

                    }
                    else
                    {
                        return false;
                    }
                    br= false;
                }
            }
            if (operations.Contains(strNew[0][0]) || operations.Contains(strNew[strNew.Length - 1][0]))
            {
                return false;
            }
            for (int i = 1; i < strNew.Length - 1; i++)
            {
                if (operations.Contains(strNew[i][0]) == operations.Contains(strNew[i + 1][0]))
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите выражение одной строкой: ");
            string str = Console.ReadLine();


            int ch1 = 0;       //проверяет на скобки

            // Все допустимые символы в уравнении
            char[] ch = new char[] { '/', '\\', '-', '+', '*', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '(', ')' };

            // Проверяет на допустимые символы и скобки
            for (int i = 0; i < str.Length; i++)
            {
                if (ch.Contains(str[i]))
                {
                    if (str[i] == '(') ch1 += 1;
                    if (str[i] == ')') ch1 -= 1;
                    if (ch1 < 0)
                    {
                        Console.WriteLine("Неправильное рассположение скобок!");
                        Console.ReadLine();
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("В строке существуют недопустимые символы!");
                    Console.ReadLine();
                    return;
                }
            }

            if (ch1 != 0)
            {
                Console.WriteLine("Недостаточно скобок!");
                Console.ReadLine();
                return;
            }

            // проверяет первый элемент
            if (str[0] == '/' || str[0] == '\\' || str[0] == '*' || str[0] == ')')
            {
                Console.WriteLine("Первый символ не может быть таким!");
                Console.ReadLine();
                return;
            }

            // проверяет последний элемент
            if (str[str.Length - 1] == '/' || str[str.Length - 1] == '\\' || str[str.Length - 1] == '*' || str[str.Length - 1] == '(')
            {
                Console.WriteLine("Последний символ не может быть таким!");
                Console.ReadLine();
                return;
            }

            char[] operations = new char[] { '/', '\\', '-', '+', '*', '(', ')' };
            string[] strNew = new string[str.Length];
            int j = 0;

            //Если в str две цифры стоят рядом преобразовывает их в число
            for (int i = 0; i < str.Length && j < strNew.Length; i++, j++)
            {

                if (str[i] >= '0' && str[i] <= '9')
                {
                    strNew[j] += str[i];
                    while ((i < str.Length - 1) && (operations.Contains(str[i + 1]) == false))
                    {
                        i++;
                        strNew[j] += str[i];
                    }
                }
                else strNew[j] += str[i];
            }
            for (int i = strNew.Length - 1; i > 0; i--)
            {
                if (strNew[i] != null)
                {
                    Array.Resize(ref strNew, i + 1);
                    break;
                }
            }

            if (Cor(strNew))
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine("Incorrect");
            }
            Console.ReadKey();
        }
    }
}
