class hw5 //почему перегрузка функций не работает без класса?
{
    //функция для ввода и его проверки
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
    static int Positive(string text)
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
    static int[] RandomArray(int Length, int Min, int Max)
    {
        Random rand = new Random();
        int[] arr = new int[Length];
        for (int i = 0; i < Length; i++) arr[i] = rand.Next(Min, Max + 1);
        Console.WriteLine($"Массив: {string.Join("; ", arr)}");
        return arr;
    }
    /*static int[] RandomArray(int Length) //здесь заполняется огромными числами из-за отсутствия границ :/ зачем, спрашивается, в перегрузку полезла?
    {
        Random rand = new Random();
        int[] arr = new int[Length];
        for (int i = 0; i < Length; i++) arr[i] = rand.Next();
        Console.WriteLine($"Массив: {string.Join("; ", arr)}");
        return arr;
    }*/
    static double SumOfOddElems(double[] arr)
    {
        double sum = 0;
        for (int i = 1; i < arr.Length; i += 2) sum += arr[i];
        return sum;
    }
    static void NumberOfEvens(int[] arr)
    {
        int num = 0;
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] % 2 == 0) num += 1;
        Console.WriteLine($"Количество чётных чисел: {num}\n");
    }
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
    static double DiffMaxMin(double[] arr)
    {
        int maxIndex = 0, minIndex = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > arr[maxIndex]) maxIndex = i;
            if (arr[i] < arr[minIndex]) minIndex = i;
        }
        return arr[maxIndex] - arr[minIndex];
    }
    static void Main()
    {
        // Задача 34: Задайте массив заполненный случайными положительными трёхзначными числами. Напишите программу, которая покажет количество чётных чисел в массиве.
        // [345, 897, 568, 234] -> 2
        Console.WriteLine("Задача 34: Найти количество чётных чисел в массиве трёхзначных чисел.");
        NumberOfEvens(RandomArray(Positive("Введите размер массива: "), 100, 999));

        // Задача 36: Задайте одномерный массив, заполненный случайными числами. Найдите сумму элементов, стоящих на нечётных позициях.
        // [3, 7, 23, 12] -> 19
        // [-4, -6, 89, 6] -> 0
        Console.WriteLine("Задача 36: Найти сумму нечётных элементов в массиве.");
        // Console.WriteLine($"Сумма нечётных элементов массива: {SumOfOddElems(RandomArray(Positive("Введите размер массива: ")))}\n"); 
        // если не поверили, что там большие цифры получаются, - можете проверить, но надо будет поменять параметр в функции с массива даблов 
        // на массив интов и закомментировать следующую строчку :р
        Console.WriteLine($"Сумма нечётных элементов массива: {SumOfOddElems(InputRealArray(Positive("Введите размер массива: ")))}\n"); //с маленькими числами всё работает

        // // Задача 38: Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементов массива.
        // // [3.22, 4.2, 1.15, 77.15, 65.2] => 77.15 - 1.15 = 76
        Console.WriteLine("Задача 38: Найти разницу между максимальным и минимальным элементов массива.");
        Console.WriteLine($"Разница между максимальным и минимальным элементами: {DiffMaxMin(InputRealArray(Positive("Введите размер массива: ")))}");
    }
}