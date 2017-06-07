using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{    
    /// <summary>
    /// Выполныет функции калькулятора: сумма, разность, умножение, деление, целочисленное деление, отмена последней операции, сброс результатов
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
        /// <returns>Сумма двух объектов типа Data</returns>
        public static Data Sum(Data first, Data second) //сумма
        {
            Data result =  first + second;
            operationsResults.Push(result);

            return result;
        }

        /// <summary>
        /// Вычитание объектов типа Data
        /// </summary>
        /// <param name="minuend">Уменьшаемое</param>
        /// <param name="subtrahend">Вычитаемое</param>
        /// <returns>Разность двух объектов</returns>        
        public static Data Dif(Data minuend, Data subtrahend) //разность
        {
            Data result = minuend - subtrahend;
            operationsResults.Push(result);

            return result;
        }

        /// <summary>
        /// Умножение объектов типа Data
        /// </summary>
        /// <param name="factor1">Первый множитель</param>
        /// <param name="factor2">Второй множитель</param>
        /// <returns>Произведение объектов типа Data</returns>
        public static Data Multiply(Data factor1, Data factor2) //умножение
        {
            Data result = factor1 * factor2;
            operationsResults.Push(result);

            return result;
        }


        /// <summary>
        /// Целочисленное деление объектов типа Data
        /// </summary>
        /// <param name="dividend">Делимое</param>
        /// <param name="divisor">Делитель</param>
        /// <returns>Частное объектов типа Data</returns>
        public static Data IntDivide(Data dividend, Data divisor) //целочисленное деление
        {
            Data result = dividend / divisor;
            operationsResults.Push(result);

            return result;
        }


        /// <summary>
        /// Деление объектов типа Data
        /// </summary>
        /// <param name="dividend">Делимое</param>
        /// <param name="divisor">Делитель</param>
        /// <returns>Вещественное частное объектов типа Data</returns>
        public static double Divide(Data dividend, Data divisor) //деление
        {
            double result = Data.Divide(dividend, divisor);
            operationsResults.Push(result);

            return result;
        }

        /// <summary>
        /// Сброс выполненных результатов
        /// </summary>        
        void Reset() //сброс результатов
        {
            operationsResults = null;
        }

        /// <summary>
        /// Отмена последней операции
        /// </summary>
        /// <param name="lastResult">Результат предпоследней операции</param>
        void Cancel(out object lastResult) 
        {            
            lastResult = operationsResults.Pop();
            lastResult = operationsResults.Pop(); //возвращение результата до последней операции
        }
    }   
}
