using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{    
    /// <summary>
    /// Выполняет функции калькулятора: сумма, разность, умножение, деление, целочисленное деление, отмена последней операции, сброс результатов
    /// </summary>
    //Функции калькулятора
    public class Calculator
    {
        public static Stack<object> operationsResults = null; //выполненные операции

        /// <summary>
        /// Сложение объектов типа Data
        /// </summary>
        /// <param name="first">Первое слагаемое</param>
        /// <param name="second">Второе слагаемое</param>
        /// <param name="errorMessage">Сообщение об ошибке. Равно string.Empty при отсутствии ошибок выполнения</param>
        /// <returns>Сумма двух объектов типа Data</returns>
        public static Data Sum(Data first, Data second, out string errorMessage)
        {
            errorMessage = string.Empty;
            Data result = new Data();
            try
            {
                result = first + second;
                operationsResults.Push(result);
            }
            catch(Exception e)
            {
                errorMessage = e.Message;
            }

            return result;
        }

        /// <summary>
        /// Вычитание объектов типа Data
        /// </summary>
        /// <param name="minuend">Уменьшаемое</param>
        /// <param name="subtrahend">Вычитаемое</param>
        /// <param name="errorMessage">Сообщение об ошибке. Равно string.Empty при отсутствии ошибок выполнения</param>
        /// <returns>Разность двух объектов</returns>        
        public static Data Dif(Data minuend, Data subtrahend, out string errorMessage)
        {
            errorMessage = string.Empty;
            Data result = new Data();

            try
            {
                result = minuend - subtrahend;
                operationsResults.Push(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }

            return result;
        }

        /// <summary>
        /// Умножение объектов типа Data
        /// </summary>
        /// <param name="factor1">Первый множитель</param>
        /// <param name="factor2">Второй множитель</param>
        /// <param name="errorMessage">Сообщение об ошибке. Равно string.Empty при отсутствии ошибок выполнения</param>
        /// <returns>Произведение объектов типа Data</returns>
        public static Data Multiply(Data factor1, Data factor2, out string errorMessage)
        {
            errorMessage = string.Empty;
            Data result = new Data();

            try
            {
                result = factor1 * factor2;
                operationsResults.Push(result);
            }
            catch(Exception e)
            {
                errorMessage = e.Message;
            }

            return result;
        }

        /// <summary>
        /// Целочисленное деление объектов типа Data
        /// </summary>
        /// <param name="dividend">Делимое</param>
        /// <param name="divisor">Делитель</param>
        /// <param name="errorMessage">Сообщение об ошибке. Равно string.Empty при отсутствии ошибок выполнения</param>
        /// <returns>Частное объектов типа Data</returns>
        public static Data IntDivide(Data dividend, Data divisor, out string errorMessage)
        {
            errorMessage = string.Empty;
            Data result = new Data();

            try
            {
                result = dividend / divisor;
                operationsResults.Push(result);
            }
            catch(Exception e)
            {
                errorMessage = e.Message;
            }

            return result;
        }


        /// <summary>
        /// Деление объектов типа Data
        /// </summary>
        /// <param name="dividend">Делимое</param>
        /// <param name="divisor">Делитель</param>
        /// <param name="errorMessage">Сообщение об ошибке. Равно string.Empty при отсутствии ошибок выполнения</param>
        /// <returns>Вещественное частное объектов типа Data</returns>
        public static double Divide(Data dividend, Data divisor, out string errorMessage)
        {
            errorMessage = string.Empty;
            double result = 0;

            try
            {
                result = Data.Divide(dividend, divisor);
                operationsResults.Push(result);
            }
            catch(Exception e)
            {
                errorMessage = e.Message;
            }

            return result;
        }

        /// <summary>
        /// Нахождение остатка от деления объеков типа Data
        /// </summary>
        /// <param name="diviend">Делимое</param>
        /// <param name="divisor">Делитель</param>
        /// <param name="errorMessage">Сообщение об ошибке. Равно string.Empty при отсутствии ошибок выполнения</param>
        /// <returns>Остаток от деления</returns>
        public static Data Mod(Data diviend, Data divisor, out string errorMessage)
        {
            errorMessage = string.Empty;
            Data result = new Data();

            try
            {
                result = diviend % divisor;
                operationsResults.Push(result);
            }
            catch(Exception e)
            {
                errorMessage = e.Message;
            }

            return result;
        }

        /// <summary>
        /// Сброс полученных результатов
        /// </summary>        
        public static void Reset()
        {
            operationsResults = null;
        }

        /// <summary>
        /// Отмена последней операции
        /// </summary>
        /// <param name="lastResult">Результат предпоследней операции. Null при отсутствии операций</param>
        /// <param name="errorMessage">Сообщение об ошибке. Равно string.Empty при отсутствии ошибок выполнения</param>
        public static void Cancel(out object lastResult, out string errorMessage) 
        {
            lastResult = null;
            errorMessage = string.Empty;

            if (operationsResults != null)
            {
                lastResult = operationsResults.Pop();

                if (operationsResults != null)
                    lastResult = operationsResults.Pop(); //возвращение результата до последней операции
                else
                    lastResult = null;
            }
            else
            {
                errorMessage = "Операции не были произведены";
            }
        }
    }   
}
