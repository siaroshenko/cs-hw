/* Задача 2: Напишите программу, которая на вход принимает два числа и выдаёт, какое число большее, а какое меньшее.
 a = 5; b = 7 -> max = 7
 a = 2 b = 10 -> max = 10
 a = -9 b = -3 -> max = -3 */
Console.WriteLine("Задача 2. Сравнение двух целых чисел.");
Console.Write("Введите число a: ");
int a = Convert.ToInt16(Console.ReadLine());
Console.Write("Введите число b: ");
int b = Convert.ToInt16(Console.ReadLine());
Console.WriteLine($"Введённые числа: {a}, {b}");
if (a > b) Console.WriteLine($"Наибольшее число - а = {a}.");
else if (a < b) Console.WriteLine($"Наибольшее число - b = {b}.");
else Console.WriteLine($"Оба числа равны {a}.");
/* Задача 4: Напишите программу, которая принимает на вход три числа и выдаёт максимальное из этих чисел.
 2, 3, 7 -> 7
 44 5 78 -> 78
 22 3 9 -> 22 */
Console.WriteLine("\nЗадача 4. Сравнение трёх целых чисел.");
Console.Write("Введите число a: ");
a = Convert.ToInt16(Console.ReadLine());
Console.Write("Введите число b: ");
b = Convert.ToInt16(Console.ReadLine());
Console.Write("Введите число c: ");
int c = Convert.ToInt16(Console.ReadLine());
Console.WriteLine($"Введённые числа: {a}, {b}, {c}");
int max = a;
if (max < b) max = b;
if (max < c) max = c;
Console.WriteLine($"Наибольшее число равно {max}.");
/* Задача 6: Напишите программу, которая на вход принимает число и выдаёт, является ли число чётным (делится ли оно на два без остатка).
 4 -> да
 -3 -> нет
 7 -> нет */
Console.WriteLine("\nЗадача 6. Проверка целого числа на чётность.");
Console.Write("Введите число: ");
a = Convert.ToInt16(Console.ReadLine());
Console.WriteLine($"Введённое число: {a}");
if (a % 2 == 0) Console.WriteLine($"Число {a} является чётным.");
else Console.WriteLine($"Число {a} является нечётным.");
/* Задача 8: Напишите программу, которая на вход принимает число (N), а на выходе показывает все чётные числа от 1 до N.
 5 -> 2, 4
 8 -> 2, 4, 6, 8 */
Console.WriteLine("\nЗадача 8. Вывод чётных чисел от 1 до N.");
Console.Write("Введите N: ");
a = Convert.ToInt16(Console.ReadLine());
Console.WriteLine($"Введённое число: {a}");
Console.WriteLine($"Чётные числа от 1 до {a}: ");
for (b = 1; b <= a; b++)
    if (b % 2 == 0) Console.Write($"{b}; ");