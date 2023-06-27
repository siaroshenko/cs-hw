using System;
class HelloWorld {
    static void Main() {
        /*Задача 10: Напишите программу, которая принимает на вход трёхзначное число и на выходе показывает вторую цифру этого числа.
        456 -> 5
        782 -> 8
        918 -> 1*/
        Console.Write("Задача 10. Введите целое трёхзначное число: ");
        string inpNum;
        while (true) {
            inpNum = Input();
            if (inpNum.Length != 3) Console.Write("Это не трёхзначное число. Попробуйте ещё раз: ");
            else break;
        }
        Console.WriteLine($"Вторая цифра числа {inpNum} - {inpNum[1]}.\n");

        /*Задача 13: Напишите программу, которая выводит третью цифру заданного числа или сообщает, что третьей цифры нет.
        645 -> 5
        78 -> третьей цифры нет
        32679 -> 6*/
        Console.Write("Задача 13. Введите целое число: ");
        inpNum = Input();
        if (inpNum.Length > 2) Console.WriteLine($"Третья цифра числа {inpNum} - {inpNum[2]}");
        else Console.WriteLine($"В числе {inpNum} нет трёх цифр :'c\n");

        /*Задача 15: Напишите программу, которая принимает на вход цифру, обозначающую день недели, и проверяет, является ли этот день выходным.
        6 -> да
        7 -> да
        1 -> нет*/
        Console.Write("Задача 13. Введите номер дня недели от 1 до 7, \nгде 1 - понедельник, а 7 - воскресенье: ");
        while (true) {
            inpNum = Input();
            int check;
            int.TryParse(inpNum, out check);
            if (inpNum.Length != 1 || (check < 1 || check > 7)) Console.Write("Вы ввели число вне диапазона. Введите число от 1 до 7 включительно: ");
            else {
                if (check > 6) Console.Write($"Число {check} соответствует выходному дню.");
                else Console.Write($"Число {check} соответствует буднему дню.");
                break;
            }
        }
    }
    //фунция для ввода и его проверки
    static string Input() {
        string inpTemp;
        while (true) {
            inpTemp = Console.ReadLine();
            int check;
            if (int.TryParse(inpTemp, out check)) break;
            else Console.Write("Это не целое число, попробуй ещё раз: ");
        }
            return inpTemp;
    }
}