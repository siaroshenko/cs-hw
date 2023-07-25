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
    return PrintNatNumbers(N-1);
}

// Задача 66: Задайте значения M и N. Напишите программу, которая найдёт сумму натуральных элементов в промежутке от M до N.
// M = 1; N = 15 -> 120
// M = 4; N = 8. -> 30
double SumOfRange(double M, double N)
{
    // случай выхода
    if(M == N)
        return N;
    // случай рекурсии
    return N + SumOfRange(M, N-1);
}

// Задача 68: Напишите программу вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n.
// m = 2, n = 3 -> A(m,n) = 9
// m = 3, n = 2 -> A(m,n) = 29
int AckermannFunc(int m, int n){
    //я пыталась понять по википедии, как эта функция работает, но так и не поняла. Математика сложно.
    //возможно, это было на семинаре, но я заснула, извините:( Одеялко оказалось ловушкой
    if (m > 0) 
        if(n > 0) return AckermannFunc(m-1, AckermannFunc(m, n-1));
        else return AckermannFunc(m-1, 1);
    else return n + 1;
}

void Main(){
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
    Console.WriteLine($"Результат вычисления функции Аккерманна: {AckermannFunc(Positive("Введите число m: "), Positive("Введите число n: "))}");
}

// функция для ввода вещественного числа
double InputNumber(string text)
{
    Console.Write(text);
    string inpTemp;
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