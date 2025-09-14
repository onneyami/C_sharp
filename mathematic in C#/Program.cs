using System;

namespace project
{
    class Programm
    {
        static void Main()
        {
            float user_input;
            Console.Write("Enter number with point: ");
            user_input = float.Parse(Console.ReadLine());

            //простые математические действия такие же, как и в остальных языках
            float result;
            result = user_input + 10;

            //сокращенные математические действия: +=, *= и так далее как и в остальных языках
            result /= 2;
            result *= 2;
            result++;
            result--;

            //встроенные математические функции
            /*
            Math.PI - вывод числа пи
            Math.E - число е
            Math.Abs() - модуль числа
            Math.Ceiling() - округление числа к большему
            Math.Floor() - округление числа к меньшему
            Math.Round() - округление в зависимости от числа
            Math.Cos() - косинус
            Math.Sin() - синус
            Math.Min() - возвращает минимальное число из двух
            Math.Max() - возвращает максимум из двух чисел
            Math.Pow() - возводит в степень
            */

            //подсчет плошади круга
            Console.WriteLine("Enter radius of circle: ");
            double radius = Convert.ToDouble(Console.ReadLine());
            double area = Math.PI * Math.Pow(radius, 2);

            Console.WriteLine("Result is: " + result);

            Console.WriteLine("Number: " + user_input);
        }
    }
}