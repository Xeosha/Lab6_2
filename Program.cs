using CreateShowArray;
using Menu;
using System.Text.RegularExpressions;

void RemoveElementsMultiplesMinimum(ref double[] array)
{
    if (array == null || array.Length == 0)
    {
        Console.WriteLine("Массив не создан"); return;
    }
    double min = array.Min();
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
        Console.WriteLine("Кратные числа удалены.");
    }
    array = newArray;
}

void Task1()
{
    double[] array = Array.Empty<double>();

    Dialog dialog = new Dialog(new[]
        {
            new Options("Создание", new Action(() => (new Dialog(new[] 
                { 
                    new Options("Создание вручную", new Action(() => CreateAndDisplay<double>.Create(ref array))),
                    new Options("Создание рандомно", new Action(() => CreateAndDisplay<double>.CreateRandom(ref array)))
                }, "Создание массива"
                )).Start())
            ),
            new Options("Вывод", new Action(() => CreateAndDisplay<double>.Display(array))),
            new Options("Удалить элементы кратные минимальному", new Action(() => RemoveElementsMultiplesMinimum(ref array)))
        }, "Задание 1."
    );
    dialog.Start();
}
static string? Create()
{
    Console.WriteLine("Введите строку: ");
    return Console.ReadLine();
}

static string? CreateSelectedRow(string oldRow)
{
    string row = oldRow;
    string[] arrRows = { "Меня зовут Данил.", "Привет, Мир!", "Не знаю, вот еще. Тут да!" };
    Dialog dialog = new Dialog(new[] {
            new Options(arrRows[0], () => { row = arrRows[0]; }),
            new Options(arrRows[1], () => { row = arrRows[1]; }),
            new Options(arrRows[2], () => { row = arrRows[2]; })
        }, 
        $"Строка: {row}\nВыберите на что заменить:"
    );

    dialog.Start();
    return row;
}

static void Show(string? row)
{
    if (string.IsNullOrEmpty(row))
        Console.WriteLine("Пустая строка");
    else
        Console.WriteLine(row);
}


static string? MoveLeft(string? row)
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

    static string RotateLeft(string word, int positions)
    {
        positions %= word.Length;
        return string.Concat(word.AsSpan(positions), word.AsSpan(0, positions));
}

static void Task2() 
{
    string row = "";

    Dialog dialog = new Dialog(new[]
        {
            new Options("Создание", new Action(() => (new Dialog(new[]
                {
                    new Options("Создание вручную", new Action(() => row = Create())),
                    new Options("Создание из списка", new Action(() => row = CreateSelectedRow(row)))
                }, "Создание строки"
                )).Start())
            ),
            new Options("Вывод", new Action(() => Show(row))),
            new Options("Сдвинуть циклически влево", new Action(() => row = MoveLeft(row)))
        }, "Задание 1."
    );
    dialog.Start();
}

Dialog dialog = new Dialog(new[]
{
    new Options("Задание 1", new Action(() => Task1())),
    new Options("Задание 2", new Action(() => Task2()))
}, "Главное меню"
);

dialog.Start();