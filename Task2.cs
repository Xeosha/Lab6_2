using Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab6_2
{
    internal class Task2
    {
        public static string? CreateConsoleRow()
        {
            Console.WriteLine("Введите строку: ");
            return Console.ReadLine();
        }

        public static string? CreateSelectedRow(string? oldRow)
        {
            string? row = oldRow;
            string[] arrRows = { "Меня зовут Данил.", "Привет, Мир!", "Не знаю, вот еще. Тут да!" };

            var dialog = new Dialog($"Строка: {row}\nВыберите на что заменить:");
            dialog.AddOption(arrRows[0], () => { row = arrRows[0]; });
            dialog.AddOption(arrRows[1], () => { row = arrRows[1]; });
            dialog.AddOption(arrRows[2], () => { row = arrRows[2]; });

            dialog.Start(); 
            return row;
        }

        public static string? CreateRow()
        {
            string? row = null;

            var dialogCreateRow = new Dialog("Создание строки");

            dialogCreateRow.AddOption("Создание вручную", () => row = Task2.CreateConsoleRow());
            dialogCreateRow.AddOption("Создание из списка", () => row = Task2.CreateSelectedRow(row));
            dialogCreateRow.Start();

            return row;
        }

        public static void Show(string? row)
        {
            if (string.IsNullOrEmpty(row))
                Console.WriteLine("Пустая строка");
            else
                Console.WriteLine(row);
        }

        public static string? MoveLeft(string? row)
        {
            if (string.IsNullOrEmpty(row))
            {
                Console.WriteLine("Пустая строка");
                return "";
            }

            // Разделяем слова по небуквенным символам
            string[] words = Regex.Split(row, @"(\W+)");

            // счетчик слов + ходим по таким небуквенным
            for (int i = 0, wordCount = 1; i < words.Length; i++)
            {
                // если пустая или не содержит буквы
                if (String.IsNullOrEmpty(words[i]) || !Regex.IsMatch(words[i], @"\w+"))
                    continue;

                words[i] = RotateLeft(words[i], wordCount);
                wordCount++;
            }
            var result = String.Concat(words);

            Console.WriteLine("Начальная строка: " + row);
            Console.WriteLine("Новая строка: " + result);
            return result;
        }

        private static string RotateLeft(string word, int positions)
        {
            positions %= word.Length;
            return string.Concat(word.AsSpan(positions), word.AsSpan(0, positions));
        }

    }
}
