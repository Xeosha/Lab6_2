using InputKeyboard;
using Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_2
{
    internal class Task1
    {
        public static double[] CreateArrayMenu()
        {
            double[] array = Array.Empty<double>();

            var dialog = new Dialog("Создание массива");
            dialog.AddOption("Создание вручную", () => array = CreateConsole());
            dialog.AddOption("Рандомное создание", () => array = CreateRandom());
            dialog.Start();

            return array;

        }
        public static double[] CreateConsole()
        {
            int n = EnterKeybord.TypeInteger("Введите размер массива: ", 0);
            double[] array = new double[n];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = EnterKeybord.TypeDouble($"Введите {i + 1} элемент массива: ");
            }

            Console.Write("Созданный массив: ");
            Display(array);

            return array;
        }
        public static double[] CreateRandom()
        {
            int n = EnterKeybord.TypeInteger("Введите размер массива: ", 0);
            double[] array = new double[n];
            var rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Math.Round(10 * rnd.NextDouble(), 1);
            }

            Console.Write("Созданный массив: ");
            Display(array);

            return array;
        }

        private static bool CheckDisplay(double[] array)
        {
            return array != null && array.Length != 0;
        }

        public static void Display(double[] array)
        {
            if (!CheckDisplay(array))
            {
                Console.WriteLine("Одномерный массив не создан или пуст");
                return;
            }

            foreach (var item in array)
            {
                Console.Write(item + "   ");
            }
            Console.WriteLine();

        }

        public static double[] RemoveElementsMultiplesMinimum(double[] array)
        {
            if (!CheckDisplay(array))
            {
                Console.WriteLine("Массив не создан или пуст"); return array;
            }
            double min = array.Min();

            double[] delElemArray = min != 0 ? array.Where(x => x % min == 0).ToArray() : Array.Empty<double>();
            double[] newArray = min != 0 ? array.Where(x => x % min != 0).ToArray() : array;

            if (min == 0)
            {
                Console.WriteLine("Минимальное число = 0");
            }
            else if (newArray.Length == array.Length)
            {
                Console.WriteLine("Кратных чисел не найдено.");
            }
            else
            {
                Console.WriteLine($"Кратные минимальному {min} удалены: ");
                foreach( var elem in delElemArray) { Console.Write(elem + " "); }
            }
            
            return newArray;
        }


    }
}
