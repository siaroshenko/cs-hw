
/*Задача 25: Напишите цикл, который принимает на вход два числа (A и B) и возводит число A в натуральную степень B.
* 3, 5 -> 243 (3⁵)
* 2, 4 -> 16*/
double A = Input("Введите число А: ");
int B = Positive("Введите степень В: ");
Console.WriteLine($"{A}^{B} = {Power(A, B)}\n");

/*Задача 27: Напишите программу, которая принимает на вход число и выдаёт сумму цифр в числе.
* 452 -> 11
* 82 -> 10
* 9012 -> 12*/
B = Positive("Введите число: ");
Console.WriteLine($"Сумма цифр в числе {B} равна {DigitSum(B)}\n");

/*Задача 29: Напишите программу, которая задаёт массив из 8 элементов в диапазоне от 10 до 1000 и выводит их на экран.
* 1, 2, 5, 7, 19 -> [1, 2, 5, 7, 19]
* 6, 1, 33 -> [6, 1, 33]*/
Console.WriteLine("Заполненный массив: ");
int[] arr = RandomArray(8, 10, 1000);
for (int i = 0; i < 8; i++) Console.Write($"{arr[i]} ");


//функция для ввода и его проверки
static double Input(string text)
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

static int Positive(string text)
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

//25
static double Power(double A, int B)
{
    double powA = A;
    for (int i = 1; i < B; i++) powA *= A;
    if (B == 0) powA = 1;
    return powA;
}

//27
static int DigitSum(int digit)
{
    int sum = 0;
    for (int i = digit; i > 0; i /= 10) sum += i % 10;
    return sum;
}

//29
static int[] RandomArray(int Length, int Min, int Max)
{
    Random rand = new Random();
    int[] arr = new int[Length];
    for (int i = 0; i < Length; i++) arr[i] = rand.Next(Min, Max + 1);
    return arr;
}