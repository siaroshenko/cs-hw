//кстати, спасибо за совет сначала прописывать возвратные значения, реально удобнее и понятнее с:

// Задача 64: Задайте значение N. Напишите программу, которая выведет все натуральные числа в промежутке от N до 1. Выполнить с помощью рекурсии.
// N = 5 -> "5, 4, 3, 2, 1"
// N = 8 -> "8, 7, 6, 5, 4, 3, 2, 1"
int PrintNatNumbers(int N)
{
    // случай выхода
    Console.Write($"{N}\t");
    if (N == 1)
        return 1;
    // случай рекурсии
    return PrintNatNumbers(N - 1);
}

// Задача 66: Задайте значения M и N. Напишите программу, которая найдёт сумму натуральных элементов в промежутке от M до N.
// M = 1; N = 15 -> 120
// M = 4; N = 8. -> 30
double SumOfRange(double M, double N)
{
    // случай выхода
    if (M == N)
        return N;
    // случай рекурсии
    return N + SumOfRange(M, N - 1);
}

// Задача 68: Напишите программу вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n.
// m = 2, n = 3 -> A(m,n) = 9
// m = 3, n = 2 -> A(m,n) = 29
int AckermannFunc(int m, int n)
{
    // я пыталась понять, как эта функция работает и зачем она нужна, но так и не поняла. Математика сложно.
    if (m > 0)
        if (n > 0) return AckermannFunc(m - 1, AckermannFunc(m, n - 1));
        else return AckermannFunc(m - 1, 1);
    else return n + 1;
}

Console.WriteLine("Задача 64: Задать значение N и вывести все натуральные числа в промежутке от N до 1.");
PrintNatNumbers(Positive("Введите число N: "));
Console.WriteLine("\n\nЗадача 66: Задать значения M и N и найти сумму натуральных элементов в промежутке от M до N.");
double M = 0, N = 0;
while (!(M < N))
{
    M = InputNumber("Введите нижнюю границу диапазона: ");
    N = InputNumber("Введите верхнюю границу диапазона: ");
    if (M >= N) Console.WriteLine("Неверный диапазон. Первое число должно быть меньше второго.");
}
Console.WriteLine($"Сумма натуральных элементов диапазона: {SumOfRange(M, N)}");
Console.WriteLine("\nЗадача 68: Даны два неотрицательных числа m и n. Вычислить для них результат применения функции Аккерманна");
// тут вообще должен быть вариант с 0 ещё доступен, но мне было лень делать ещё одну функцию проверки, поэтому как-то так с: 
// но при желании можете поставить вместо функций Positive нули - должно работать
// при аргументах 4 и 4 у меня всё сломалось, потому что рекурсия прошла 19272 круга, и случился стак оверфлоу, не повторяйте
Console.WriteLine($"Результат вычисления функции Аккерманна: {AckermannFunc(Positive("Введите число m: "), Positive("Введите число n: "))}");

// а дальше вы уже всё раз 5 видели, эти функции у меня из дз в дз кочуют :р

// функция для ввода вещественного числа
double InputNumber(string text)
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

// функция для ввода целого положительного числа
int Positive(string text)
{
    double number;
    while (true)
    {
        number = InputNumber(text);
        if (number == Math.Round(number) && number > 0) break;
        else Console.WriteLine("Введите целое положительное число.");
    }
    return Convert.ToInt32(number);
}