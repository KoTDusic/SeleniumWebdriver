using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Calculator
    {
        double result;
        public Calculator()
        {
            result = 0;
        }

        public double calculate(Char operation, double v1, double v2)
        {
            switch (operation)
    
        {
                case '+':
                    return v1 + v2;
                case '-':
                    return v1 - v2;
                case '*':
                    return v1 * v2;
                case '/':
                    return v1 / v2;
                default:
                    Exception e = new Exception("введена неизвестная операция");
                    throw e;
            }
        }

        public string FormatResult(Char operation, double v1, double v2)
        {
            String res="";
            try
            {
                result = calculate(operation, v1, v2);
                res += String.Format("результат вычисления {0} {1} {2} = {3}", v1, operation, v2, result);
            }
            catch (Exception e)
            {
                res += String.Format("неверные входные данные, произошла ошибка:{0}", e.Message);
            }
            return res;
        }
    }
}
