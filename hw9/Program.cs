// Задача 64: Задайте значение N. Напишите программу, которая выведет все натуральные числа в промежутке от N до 1. Выполнить с помощью рекурсии.
// N = 5 -> "5, 4, 3, 2, 1"
// N = 8 -> "8, 7, 6, 5, 4, 3, 2, 1"
void PrintNatNumbers(int N)
{
    Console.Write($"{N}\t");
    if (N > 1)
        PrintNatNumbers(N - 1);
    return;
}

// Задача 66: Задайте значения M и N. Напишите программу, которая найдёт сумму натуральных элементов в промежутке от M до N.
// M = 1; N = 15 -> 120
// M = 4; N = 8. -> 30
double SumOfRange(double M, double N)
{
    if(M > N) 
    return;
}

// Задача 68: Напишите программу вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n.
// m = 2, n = 3 -> A(m,n) = 9
// m = 3, n = 2 -> A(m,n) = 29

PrintNatNumbers(Positive("Введите число N: "));
double M = 0, N = 0;
while (!(M < N))
{
    M = InputNumber("Введите нижнюю границу диапазона: ");
    N = InputNumber("Введите верхнюю границу диапазона: ");
    if (M >= N) Console.WriteLine("Неверный диапазон. Первое число должно быть меньше второго.");
}
SumOfRange(M, N);

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