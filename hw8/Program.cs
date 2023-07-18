class hw7
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
        PrintMatrix("Ваш массив: ", arr);
        return arr;
    }

    //функция для определения размеров двумерного массива
    static void MatrixSize(ref int rows, ref int col, double[,] arr)
    {
        col = arr.GetUpperBound(0) + 1;
        rows = arr.Length / col;
    }

    //функция для сортировки элементов внутри строки
    static void SortByRows(ref double[,] arr)
    {
        int rows = 0, col = 0;
        MatrixSize(ref rows, ref col, arr);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < col - 1; j++)
            {
                for (int k = 0; k < col - j - 1; k++)
                {
                    if (arr[k, i] < arr[k + 1, i])
                    {
                        double temp = arr[k, i];
                        arr[k, i] = arr[k + 1, i];
                        arr[k + 1, i] = temp;
                    }
                }
            }
        }
        PrintMatrix("\nОтсортированный массив:", arr);
    }

    //функция для поиска строки с наименьшей суммой элементов
    static int LeastSumRow(double[,] arr)
    {
        int rows = 0, col = 0;
        double sum1, sum2;
        MatrixSize(ref rows, ref col, arr);
        int rowNum = 0;
        for (int i = 1; i < rows - 1; i++)
        {
            sum1 = sum2 = 0;
            for (int j = 0; j < col; j++)
            {
                sum1 += arr[j, rowNum];
                sum2 += arr[j, i];
            }
            if (sum1 > sum2) rowNum = i;
        }
        Console.WriteLine($"Номер строки с наименьшей суммой элементов: {rowNum + 1}");
        return rowNum + 1;
    }

    //функция печати матрицы
    static void PrintMatrix(string text, double[,] arr)
    {
        int rows = 0, col = 0;
        MatrixSize(ref rows, ref col, arr);
        Console.WriteLine($"{text}");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < col; j++) Console.Write($"{arr[j, i]}\t");
            Console.WriteLine();
        }
    }

    //функция проверки совместимости матриц
    static bool MatrixCompatibilityCheck(double[,] matrixA, double[,] matrixB)
    {
        int rowsA = 0, colA = 0, rowsB = 0, colB = 0;
        MatrixSize(ref rowsA, ref colA, matrixA);
        MatrixSize(ref rowsB, ref colB, matrixB);
        if (colA == rowsB) return true;
        else return false;
    }

    //функция перемножения матриц
    static double[,] MatrixMultiplication(double[,] matrixA, double[,] matrixB)
    {
        int rowsA = 0, colA = 0, rowsB = 0, colB = 0;
        MatrixSize(ref rowsA, ref colA, matrixA);
        MatrixSize(ref rowsB, ref colB, matrixB);
        double[,] matrixResult = new double[colB, rowsA];
        if (MatrixCompatibilityCheck(matrixA, matrixB) == false)
        {
            Console.WriteLine("Матрицы не могут быть перемножены!");
            return matrixResult;
        }
        for (int j = 0; j < rowsA; j++)
            for (int k = 0; k < colB; k++)
                for (int i = 0; i < colA; i++)
                    matrixResult[k, j] += matrixA[i, j] * matrixB[k, i];
        PrintMatrix("Результирующая матрица:", matrixResult);
        return matrixResult;
    }

    static void Main()
    {
        /*Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
        Например, задан массив:
        1 4 7 2
        5 9 2 3
        8 4 2 4
        В итоге получается вот такой массив:
        7 4 2 1
        9 5 3 2
        8 4 4 2*/
        //double[,] arr = InputReal2DArray(Positive("Введите количество строк: "), Positive("Введите количество элементов в строке: "));
        //SortByRows(ref arr);

        /*Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
        Например, задан массив:
        1 4 7 2
        5 9 2 3
        8 4 2 4
        5 2 6 7
        Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка*/
        //LeastSumRow(arr);

        /*Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
        Например, даны 2 матрицы:
        2 4 | 3 4
        3 2 | 3 3
        Результирующая матрица будет:
        18 20
        15 18*/
        //MatrixMultiplication(InputReal2DArray(Positive("Введите количество строк для матрицы А: "), Positive("Введите количество столбцов для матрицы A: ")),
        //                    InputReal2DArray(Positive("Введите количество строк для матрицы B: "), Positive("Введите количество столбцов для матрицы B: ")));

        /*Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
        Массив размером 2 x 2 x 2
        66(0,0,0) 25(0,1,0)
        34(1,0,0) 41(1,1,0)
        27(0,0,1) 90(0,1,1)
        26(1,0,1) 55(1,1,1)*/

        /*Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
        Например, на выходе получается вот такой массив:
        01 02 03 04
        12 13 14 05
        11 16 15 06
        10 09 08 07*/
    }
}