using System;
class homework
{
    static void Main()
    {
        /*19. Напишите программу, которая принимает на вход пятизначное число и проверяет, является ли оно палиндромом.
        * 14212 -> нет
        * 12821 -> да
        * 23432 -> да*/
        //Для 5-значных чисел
        double N;
        while (true)
        {
            N = Convert.ToDouble(Input("Введите пятизначное число: "));
            if (N >= 10000 && Math.Round(N) < 100000) break;
            else Console.Write("Это не пятизначное число. Попробуйте ещё раз. ");
        }
        if (N != Math.Round(N))
        {
            Console.WriteLine($"Число {N} будет преобразовано в целое число {Math.Round(N)}");
        }
        int n = Convert.ToInt32(N), revN = 0;
        for (int i = n; i > 0; i /= 10)
        {
            revN = revN * 10 + i % 10;
        }
        if (n == revN) Console.WriteLine($"{n} - это палиндром.\n");
        else Console.WriteLine($"{n} не является палиндромом.\n");

        //Для любых строк
        Console.Write("Введите строку: ");
        string? str = Console.ReadLine();
        bool check = true;
        for (int i = 0; i < str.Length / 2; i++)
        {
            if (str[i] != str[str.Length - 1 - i]) check = false;
        }
        if (check == true) Console.WriteLine($"{str} - это палиндром.\n");
        else Console.WriteLine($"{str} не является палиндромом.\n");

        /*21. Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 3D пространстве.
        * A(3, 6, 8); B(2, 1, -7), -> 15.84
        * A(7, -5, 0); B(1, -1, 9)-> 11.53*/
        double[] A = new double[3];
        double[] B = new double[3];
        for (int i = 0; i < 3; i++)
        {
            A[i] = Convert.ToDouble(Input($"Введите координату {i + 1} для точки А: "));
            B[i] = Convert.ToDouble(Input($"Введите координату {i + 1} для точки В: "));
        }
        Console.WriteLine($"Расстояние между точками А и В составляет {Math.Round(Math.Sqrt(Math.Pow(A[1] - B[1], 2) + Math.Pow(A[0] - B[0], 2) + Math.Pow(A[2] - B[2], 2)), 2)}\n");

        /*23. Напишите программу, которая принимает на вход число (N) и выдаёт таблицу кубов чисел от 1 до N.
        * 3 -> 1, 8, 27
        * 5 -> 1, 8, 27, 64, 125*/
        N = Convert.ToDouble(Input("Введите число: "));
        if (N != Math.Round(N))
        {
            Console.WriteLine($"Число {N} было преобразовано в целое число {Math.Round(N)}");
        }
        for (int i = 1; i <= Convert.ToInt32(N); i++)
        {
            Console.WriteLine($"{i}^3 = {Math.Pow(i, 3)}");
        }
    }
    //фунция для ввода и его проверки
    static string Input(string text)
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
        return inpTemp;
    }
}
