using CreateShowArray;
using Menu;
using System.Text.RegularExpressions;
using Lab6_2;

static void FirstTask()
{
    double[] array = Array.Empty<double>();

    var dialog = new Dialog("Задание 1");
    dialog.AddOption("Создание массива", () => array = Task1.CreateArrayMenu(), true);
    dialog.AddOption("Вывод", () => Task1.Display(array));
    dialog.AddOption("Удалить элементы кратные минимальному", () => array = Task1.RemoveElementsMultiplesMinimum(array));

    dialog.Start();                     
}

static void SecondTask() 
{
    string? row = null;

    var dialog = new Dialog("Задание 2");
    dialog.AddOption("Создание", () => row = Task2.CreateRow(), true);
    dialog.AddOption("Вывод", () => Task2.Show(row));
    dialog.AddOption("Сдвинуть циклически влево", () => row = Task2.MoveLeft(row));

    dialog.Start();  
}

var dialog = new Dialog(new[]
{
    new Options("Задание 1", FirstTask, true),
    new Options("Задание 2", SecondTask, true)
}, "Главное меню"
);

dialog.Start();