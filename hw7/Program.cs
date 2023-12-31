﻿class hw7
{
    //функция для ввода вещественного числа
    static double InputNumber(string text)
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

    //функция для ввода целого положительного числа
    static int Positive(string text)
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

    //функция для ввода двумерного массива вещественных чисел
    static double[,] InputReal2DArray(int rows, int col)
    {
        double[,] arr = new double[col, rows];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < col; j++)
            {
                arr[j, i] = InputNumber($"Введите элемент {j + 1} строки {i + 1} массива: ");
            }
        }
        Console.Clear();
        Console.WriteLine("Ваш массив: ");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Console.Write($"{arr[j, i]}\t");
            }
            Console.WriteLine();
        }
        return arr;
    }

    //функция для поиска элемента по индексу в двумерном массиве вещественных чисел
    static double ElementByIndex(double[,] arr, int rowIndex, int colIndex)
    {
        if (rowIndex >= arr.GetUpperBound(0) + 1 || colIndex >= arr.Length / arr.GetUpperBound(0) + 1)
        {
            Console.WriteLine($"В массиве нет элемента с индексом [{rowIndex}, {colIndex}].");
            return 0;
        }
        if (rowIndex < 0 || colIndex < 0)
        {
            Console.WriteLine($"Один из индексов меньше 0.");
            return 0;
        }
        Console.WriteLine($"Элемент с индексом [{rowIndex}, {colIndex}]: {arr[colIndex, rowIndex]}");
        return arr[colIndex, rowIndex];
    }

    //функция для расчёта среднего арифметического в столбце
    static double[] AvgByColumn(double[,] arr)
    {
        int col = arr.GetUpperBound(0) + 1;
        int rows = arr.Length / col;
        double[] buffArr = new double[col];
        for (int i = 0; i < col; i++)
        {
            double sum = 0;
            for (int j = 0; j < rows; j++) sum += arr[i, j];
            buffArr[i] = sum / rows;
        }
        Console.WriteLine($"Среднее арифметическое каждого столбца: {string.Join("; ", buffArr)}.");
        return buffArr;
    }

    static void Main()
    {
        /*Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
        m = 3, n = 4.
        0,5 7 -2 -0,2
        1 -3,3 8 -9,9
        8 7,8 -7,1 9*/
        double[,] arr = InputReal2DArray(Positive("Введите количество строк: "), Positive("Введите количество элементов в строке: "));

        /*Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.
        Например, задан массив:
        1 4 7 2
        5 9 2 3
        8 4 2 4
        17 -> такого числа в массиве нет*/
        ElementByIndex(arr, Positive("Введите номер строки: ") - 1, Positive("Введите номер столбца: ") - 1);

        /*Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
        Например, задан массив:
        1 4 7 2
        5 9 2 3
        8 4 2 4
        Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.*/
        AvgByColumn(arr);
    }
}