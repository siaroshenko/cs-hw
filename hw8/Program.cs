class hw8
{
    // функция для ввода вещественного числа
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

    // функция для ввода целого положительного числа
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

    // функция для ввода двумерного массива вещественных чисел
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

    // функция для определения размеров двумерного массива
    static void MatrixSize(ref int rows, ref int col, double[,] arr)
    {
        col = arr.GetUpperBound(0) + 1;
        rows = arr.Length / col;
    }

    // функция для сортировки элементов внутри строки
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

    // функция для поиска строки с наименьшей суммой элементов
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

    // функция печати матрицы
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

    // функция проверки совместимости матриц
    static bool MatrixCompatibilityCheck(double[,] matrixA, double[,] matrixB)
    {
        int rowsA = 0, colA = 0, rowsB = 0, colB = 0;
        MatrixSize(ref rowsA, ref colA, matrixA);
        MatrixSize(ref rowsB, ref colB, matrixB);
        if (colA == rowsB) return true;
        else return false;
    }

    // функция перемножения матриц
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

    // функция для спирального заполнения матрицы 4х4
    static double[,] Spiral2DArray()
    // это должно работать и для других размеров матриц (в т.ч. и для не квадратных матриц), но нужно учитывать количество шагов и правильно поменять значения
    {
        double[,] arr = new double[4, 4];
        // М мы используем для рассчётов по вертикали (т.е. оно должно быть равным количеству строк)
        // N - для рассчётов по горизонтали (т.е. оно равно количеству столбцов)
        int rows = 4, col = 4, M = 4, N = 4;
        int i = 0, j = 0;
        for (int step = 0; step < 8; step++)
        // количество шагов зависит от количества узлов. Например, в спирали матрицы 4х4 у нас 6 углов и ещё начало и конец => получаем 8 узлов
        {
            // верхняя сторона спирали
            if (step % 4 == 0)
            // всё, что делится на 4, делится и на 2, поэтому удобнее сначала учесть то, что делится на 4
            {
                do
                {
                    arr[i, j] = InputNumber($"Введите элемент [{i}, {j}] массива: ");
                    i++;
                } while (i < col - 1);
                col--;
            }

            // нижняя сторона спирали
            else if (step % 2 == 0)
            {
                do
                {
                    arr[i, j] = InputNumber($"Введите элемент [{i}, {j}] массива: ");
                    i--;
                } while (i > N - col - 1);
            }

            // левая сторона спирали
            else if ((step + 1) % 4 == 0) // с левой стороны у нас будут грани 3, 7, 11 и т.д., с правой 1, 5, 9 и т.д.
            {
                do // если здесь взять вайл, а не ду вайл, то последний (центральный) элемент не будет учитываться
                {
                    arr[i, j] = InputNumber($"Введите элемент [{i}, {j}] массива: ");
                    j--;
                } while (j > M - rows);
            }

            // правая сторона спирали
            else
            {
                do
                {
                    arr[i, j] = InputNumber($"Введите элемент [{i}, {j}] массива: ");
                    j++;
                } while (j < rows - 1);
                rows--;
            }
        }
        Console.Clear();
        PrintMatrix("Массив, заполненный по спирали: ", arr);
        return arr;
    }

    // функция для проверки элемента на уникальность
    static bool ElemCheck(int[,,] arr, int elem)
    {
        int d1 = arr.GetLength(0);
        int d2 = arr.GetLength(1);
        int d3 = arr.GetLength(2);
        int count = 0;
        for (int i = 0; i < d1; i++)
            for (int j = 0; j < d2; j++)
                for (int k = 0; k < d3; k++)
                {
                    if (arr[i, j, k] == elem) count++;
                    if (count > 1) return false;
                }
        return true;
    }

    // функция для заполнения 3-хмерного массива
    static int[,,] Random3DArray(int height, int length, int width)
    {
        int[,,] arr = new int[height, length, width];
        Random rand = new Random();
        for (int i = 0; i < height; i++)
            for (int j = 0; j < length; j++)
            {
                int k = 0;
                while (k < width)
                {
                    arr[i, j, k] = rand.Next(10, 100);
                    if (ElemCheck(arr, arr[i, j, k])) k++;
                }
            }
        return arr;
    }

    // функция для построчного вывода 3-мерного массива с указанием индексов
    static void Print3DArrayByRows(int[,,] arr)
    {
        int d1 = arr.GetLength(0);
        int d2 = arr.GetLength(1);
        int d3 = arr.GetLength(2);
        Console.WriteLine("\nПолученный массив: ");
        for (int k = 0; k < d3; k++)
        {
            for (int i = 0; i < d1; i++)
            {
                for (int j = 0; j < d2; j++)
                    Console.Write($"{arr[i, j, k]} ({i}, {j}, {k})\t");
                Console.WriteLine();
            }
        }
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
        Console.WriteLine("Задача 54. Задать двумерный массив и отсортировать элементы каждой строки по убыванию.");
        double[,] arr = InputReal2DArray(Positive("Введите количество строк: "), Positive("Введите количество элементов в строке: "));
        SortByRows(ref arr);
        Console.WriteLine("\nНажмите Enter, чтобы продолжить.");
        Console.Read();

        /*Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
        Например, задан массив:
        1 4 7 2
        5 9 2 3
        8 4 2 4
        5 2 6 7
        Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка*/
        Console.Clear();
        Console.WriteLine("\nЗадача 56. Найти строку с наименьшей суммой элементов в двумерном массиве.");
        PrintMatrix("Используемый массив: ", arr);
        LeastSumRow(arr);
        Console.WriteLine("\nНажмите Enter, чтобы продолжить.");
        Console.Read();

        /*Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
        Например, даны 2 матрицы:
        2 4 | 3 4
        3 2 | 3 3
        Результирующая матрица будет:
        18 20
        15 18*/
        Console.Clear();
        Console.WriteLine("\nЗадача 58. Задать две матрицы и найти их произведение.");
        MatrixMultiplication(InputReal2DArray(Positive("Введите количество строк для матрицы А: "), Positive("Введите количество столбцов для матрицы A: ")),
                            InputReal2DArray(Positive("Введите количество строк для матрицы B: "), Positive("Введите количество столбцов для матрицы B: ")));
        Console.WriteLine("\nНажмите Enter, чтобы продолжить.");
        Console.Read();

        /*Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
        Массив размером 2 x 2 x 2
        66(0,0,0) 25(0,1,0)
        34(1,0,0) 41(1,1,0)
        27(0,0,1) 90(0,1,1)
        26(1,0,1) 55(1,1,1)*/
        Console.Clear();
        Console.WriteLine("\nЗадача 60. Сформировать трёхмерных массив из неповторяющихся двузначных чисел \nи вывести этот массив построчно с указанием индексов элементов.");
        Print3DArrayByRows(Random3DArray(Positive("Введите размерность 1 трёхмерного массива: "),
                                        Positive("Введите размерность 2 трёхмерного массива: "),
                                        Positive("Введите размерность 3 трёхмерного массива: ")));
        Console.WriteLine("\nНажмите Enter, чтобы продолжить.");
        Console.Read();

        /*Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
        Например, на выходе получается вот такой массив:
        01 02 03 04
        12 13 14 05
        11 16 15 06
        10 09 08 07*/
        Console.Clear();
        Console.WriteLine("\nЗадача 62. Спирально заполнить массив 4х4.");
        Spiral2DArray();
    }
}