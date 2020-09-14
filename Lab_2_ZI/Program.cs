using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_ZI
{
    class Program
    {
        /// <summary>
        /// Проверка, является ли число простым
        /// </summary>
        /// <param name="n"> Число для проверки </param>
        static public bool Prime(int n)
        {
            bool prost = true;
            for (int i = 2; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    prost = false;
                    break;
                }
            }
            if (prost)
            {
                return prost;
            }
            else
            {
                return prost;
            }
        }


        /// <summary>
        /// Нахождение первообразного корня
        /// </summary>
        /// <param name="p"> Число, от которого находим корень</param>
        /// <returns> Корень </returns>
        public static int GetPRoot(int p)
        {
            for (int i = 0; i < p; i++)
                if (IsPRoot(p, i))
                    return i;
            return 0;
        }

        /// <summary>
        /// Вспомогательная функция для GetPRoot
        /// </summary>
        /// <param name="p"></param>
        /// <param name="a"> Параметр для перебора </param>
        /// <returns> Элемент </returns>
        public static bool IsPRoot(int p, int a)
        {
            if (a == 0 || a == 1)
                return false;
            int last = 1;
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < p - 1; i++)
            {
                last = (last * a) % p;
                if (set.Contains(last)) // Если повтор
                    return false;
                set.Add(last);
            }
            return true;
        }


        /// <summary>
        /// Поиск ближайшего первообразного корня к числу M
        /// </summary>
        /// <param name="M"></param>
        /// <returns></returns>
        public static int NumP (int M)
        {
            int P = M + 1;
            for (int i = 0; M < M + 9999; i++)
            {
                if (Prime(P) == true)
                {
                    return P;
                }
                P++;
            }
            return 0;
        }

        static void Main(string[] args)
        {
            var rnd = new Random();
            Console.Write($"Введите число М: ");
            var M = Convert.ToInt32(Console.ReadLine());

            var p = NumP(M);

            var g = GetPRoot(p);

            ///От 1 до p - 1, но .Next [x, y)
            var k = rnd.Next(2, p - 1);

            ///Сессионный (закрытый) ключ
            var x = rnd.Next(2, p - 1);

            ///Открытый ключ (p, g, y)
            var y = Math.Pow(g, x) % p;

            ///Пара чисел (a, b) является шифротекстом
            var a = Math.Pow(g, k) % p;
            var b = Math.Pow(y, k) * M % p;

            Console.WriteLine("Шифротекст (a, b): ({0}, {1})", a, b);
            Console.WriteLine("Открытый ключ (p, g, y) = ({0}, {1}, {2})", p, g, y);
            Console.WriteLine("Закрытый ключ x = {0}", x);

            end:
            Console.WriteLine("Нажмите 1, чтобы расшифровать или 0, чтобы закрыть программу");

            var flag = Convert.ToInt32(Console.ReadLine());

            if (flag == 0)
            {
                return;
            } 
            else if (flag == 1)
            {
                Console.WriteLine("Введите шифротекст в формате: а = ..., b = ...");
                a = Convert.ToInt32(Console.ReadLine());
                b = Convert.ToInt32(Console.ReadLine());

                Console.Write("Закрытый ключ x = ");
                x = Convert.ToInt32(Console.ReadLine());

                M = Convert.ToInt32(b * Math.Pow(a, p - 1 - x) % p);


                Console.WriteLine("Зашифрованное число: {0}", M);
                Console.ReadKey();
            }
            else
                goto end;            
        }
    }
}
