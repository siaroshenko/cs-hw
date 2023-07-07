//функция для ввода и его проверки
double Input(string text)
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

int Positive(string text)
{
    double number;
    while (true)
    { //мне было слишком лень, да
        number = Input(text);
        if (number == Math.Round(number) && number > 0) break;
        else Console.WriteLine("Введите целое положительное число.");
    }
    return Convert.ToInt32(number);
}

int[] RandomArray(int Length, int Min, int Max)
{
    Random rand = new Random();
    int[] arr = new int[Length];
    for (int i = 0; i < Length; i++) arr[i] = rand.Next(Min, Max + 1);
    return arr;
}

int[] RandomArray(int Length)
{
    Random rand = new Random();
    int[] arr = new int[Length];
    for (int i = 0; i < Length; i++) arr[i] = rand.Next();
    return arr;
}

void main()
{
    // Задача 34: Задайте массив заполненный случайными положительными трёхзначными числами. Напишите программу, которая покажет количество чётных чисел в массиве.
    // [345, 897, 568, 234] -> 2
    Console.WriteLine("Задача 34: Найти количество чётных чисел в массиве трёхзначных чисел.");
    NumberOfEvens(RandomArray(Positive("Введите размер массива: "), 100, 999));

    void NumberOfEvens(int[] arr)
    {
        int num = 0;
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] % 2 == 0) num += 1;
        Console.WriteLine($"Массив: {string.Join("; ", arr)}\n"
        + $"Количество чётных чисел: {num}\n");
    }

    // Задача 36: Задайте одномерный массив, заполненный случайными числами. Найдите сумму элементов, стоящих на нечётных позициях.
    // [3, 7, 23, 12] -> 19
    // [-4, -6, 89, 6] -> 0
    Console.WriteLine("Задача 36: Найти сумму нечётных элементов в массиве.");
    SumOfOddElems(RandomArray(Positive("Введите размер массива: ")));

    int SumOfOddElems(int[] arr)
    {
        int sum = 0;
        for (int i = 1; i < arr.Length; i += 2) sum += arr[i];
        return sum;
    }

    // Задача 38: Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементов массива.
    // [3.22, 4.2, 1.15, 77.15, 65.2] => 77.15 - 1.15 = 76

}