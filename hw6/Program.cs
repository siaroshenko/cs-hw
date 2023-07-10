// Задача 41: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.
// 0, 7, 8, -2, -2 -> 2
// 1, -7, 567, 89, 223-> 3
NumberOfPositive(InputRealArray(PositiveInt("Сколько чисел вы хотите ввести?\n")));
Pause();

// Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых, 
// заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.
// b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)
// k1 * x + b1 = k2 * x + b2 => x = (b2 - b1) / (k1 - k2)
// y = k1 * x + b1
double k1 = InputNumber("Введите k1: ");
double b1 = InputNumber("Введите b1: ");
double k2 = InputNumber("Введите k2: ");
double b2 = InputNumber("Введите b2: ");
Console.WriteLine($"Полученные уравнения:\n\ty = {k1} * x + {b1}\n\ty = {k2} * x + {b2}");
Console.WriteLine($"Точка пересечения прямых: А({Math.Round((b2 - b1) / (k1 - k2), 3)}; {Math.Round(k1 * (b2 - b1) / (k1 - k2) + b1, 3)})\n");

//пауза
void Pause()
{
    Console.WriteLine("Нажмите Enter, чтобы перейти к следующей задаче.");
    Console.Read();
    Console.Clear();
}
//проверяем, что ввод - число
static double InputNumber(string text)
{
    Console.Write(text);
    string? inpTemp;
    while (true)
    {
        inpTemp = Console.ReadLine();
        double check;
        if (Double.TryParse(inpTemp, out check)) break;
        else Console.Write("Это не число, попробуйте ещё раз: ");
    }
    return Convert.ToDouble(inpTemp);
}
//проверяем, что число целое и положительное
static int PositiveInt(string text)
{
    double number;
    while (true)
    { //мне было слишком лень, да
        number = InputNumber(text);
        if (number == Math.Round(number) && number > 0) break;
        else Console.WriteLine("Введите целое положительное число.");
    }
    return Convert.ToInt32(number);
}
//заполняем массив рандомными числами в определённом диапазоне
static int[] RandomArray(int Length, int Min, int Max)
{
    Random rand = new Random();
    int[] arr = new int[Length];
    for (int i = 0; i < Length; i++) arr[i] = rand.Next(Min, Max + 1);
    Console.WriteLine($"Массив: {string.Join("; ", arr)}");
    return arr;
}
//ввод массива чисел
static double[] InputRealArray(int size)
{
    double[] arr = new double[size];
    for (int i = 0; i < size; i++)
    {
        arr[i] = InputNumber($"Введите элемент {i} массива: ");
    }
    Console.Clear();
    Console.WriteLine($"Ваш массив: [{string.Join("; ", arr)}]");
    return arr;
}
//подсчет количества чисел больше 0
void NumberOfPositive(double[] arr)
{
    int num = 0;
    for (int i = 0; i < arr.Length; i++)
        if (arr[i] > 0) num++;
    Console.WriteLine($"Количество положительных чисел: {num}\n");
}