using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class CalculatorController
    {
        Calculator calculator;
        double value1, value2;
        char operation;
        const String description = "калькулятор v0.1, доступные операции: сложение(+),вычитание(-),умножение(*), деление(/)";

        public CalculatorController()
        {
            calculator = new Calculator();
            Console.WriteLine(description);
        }

        public void ReadValuesAndCalculate()
        {
            Console.Write("ведите операцию");
            operation = Convert.ToChar(Console.ReadLine()); //.ReadKey().KeyChar
            Console.WriteLine();
            Console.Write("операция принята");
            Console.WriteLine();
            while (true)
            {
                try
                {
                    Console.Write("ведите первый операнд: ");
                    value1 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine();
                    break;
                }
                catch 
                {
                    Console.WriteLine("ошибка в вводе первого операнда, вводить число, отделяя дробную часть точкой");
    
            }
            }
            while (true)
            {
                try
                {
                    Console.Write("ведите второй операнд: ");
                    value2 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine();
                    break;
                }
                catch
                {
                    Console.WriteLine("ошибка в вводе второго операнда, вводить число, отделяя дробную часть точкой");
    
            }
            }
            Console.WriteLine(calculator.FormatResult(operation, value1, value2));
        }
    }
}
