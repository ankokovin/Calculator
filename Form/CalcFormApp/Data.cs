using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

/*
 * Написанные операции: + -  * / /цел %
 */

namespace Functions
{
    /// <summary>
    /// Непосредственно хранит длинные числа и содержит реализацию функций сложения, вычитания, умножения, целочисленного и нет деления
    /// Способ хранения: массив из <see cref="N"/> разрядов <see cref="Base"/>-ичной системы исчисления типа <see cref="long"/>
    /// </summary>
    public class Data
    {
        /// <summary>
        /// Количество используемых разрядов
        /// </summary>
        int Count
        {
            get
            { for (int i = N - 1; i > 0; i--)
                    if (Digits[i] != 0) return i + 1;
                return 1;
            }
        }
        /// <summary>
        /// Максимальное количество разрядов
        /// </summary>
        const int N = 5;
        /// <summary>
        /// Массив элементов типа <see cref="long"/>, хранящий разряды
        /// </summary>
        long[] Digits = new long[N];
        /// <summary>
        /// Является ли данное число типа <see cref="Data"/> положительным
        /// </summary>
        bool Plus = true;
        /// <summary>
        /// Основание СИ
        /// </summary>
        const int Base = 100000;
        /// <summary>
        /// Инициализация числа 0 типа <see cref="Data"/>
        /// </summary>
        public Data()
        {
            
        }
        /// <summary>
        /// Инициализация числа типа <see cref="Data"/> по строке <see cref="string"/>
        /// </summary>
        /// <param name="Input">Входная строка <see cref="string"/></param>
        public Data(string Input) 
        {
            if (Input.Length > 26) throw new Exception("Слишком большая строка");
            Regex check = new Regex("^-?[0-9]+$");
            if (!check.IsMatch(Input)) throw new Exception("Неверное представление");
            if (Input[0] == '-')
            {
                Plus = false;
                Input=Input.Remove(0, 1);
            }
            if (Input.Length > 25) throw new Exception("Слишком большая строка");
            int count = 0;
            while (Input.Length>5)
            {
                Digits[count] = int.Parse(Input.Substring(Input.Length - 5));
                count++;
                Input=Input.Remove(Input.Length - 5);
            }
            Digits[count]= int.Parse(Input);
        }
        #region Операторы сравнения
        public static bool operator < (Data first, Data second)
        {
            if (first.Plus != second.Plus)
            {
                if (first.Plus) return false;
                else return true;
            }
            if (first.Count > second.Count) return false;
            if (second.Count > first.Count) return true;
            for (int i = first.Count - 1; i >= 0; i--)
            {
                if (first.Digits[i] < second.Digits[i]) return true;
                if (first.Digits[i] > second.Digits[i]) return false;
            }
            return false;
        }
        public static bool operator >(Data first, Data second)
        {
            return !(first < second) && !(first == second);
        }
        public static bool operator == (Data first, Data second)
        {
            if (first.Plus != second.Plus || first.Count != second.Count)
            {
                return false;
            }
            for (int i = 0; i < first.Count; i++) if (first.Digits[i] != second.Digits[i]) return false;
            return true;
        }
        public static bool operator != (Data first, Data second)
        {
            return !(first == second);
        }
        #endregion Операторы сравнения
        /// <summary>
        /// Глубокое копирование данного числа  <see cref="Data"/> 
        /// </summary>
        /// <returns>Копия данного числа типа  <see cref="Data"/> </returns>
        public Data Copy()
        {
            Data result = new Data();
            for (int i = 0; i < Digits.Length; i++) result.Digits[i] = Digits[i];
            result.Plus = Plus;
            return result;
        }
        /// <summary>
        /// Самое большое возможное число типа  <see cref="Data"/> 
        /// </summary>
        public static Data MaxValue
        {
            get
            {
                return new Data("9999999999999999999999999");
            }
        }
        /// <summary>
        /// Представление единицы в число типа  <see cref="Data"/> 
        /// </summary>
        public static Data One
        {
            get
            {
                return new Data("1");
            }
        }
        /*          Сложение
         *  Возможные случаи:
         *      1) Одинаковые знаки -> Выполняется обычное сложение, знак результата = знак входных чисел
         *      2) Разные знаки -> Следует привести к вычитанию 
         *          a+b = a-(-b) = b-(-a)
         *          Наименьший следует использовать в качестве вычитаемого!
         * 
         */ 
         /// <summary>
         /// Сложение двух чисел типа <see cref="Data"/>
         /// </summary>
         /// <param name="first">Первое слагаемое типа <see cref="Data"/></param>
         /// <param name="second">Второе слагаемое типа <see cref="Data"/></param>
         /// <returns>Сумма слагаемых типа <see cref="Data"/></returns>
        public static Data operator + (Data first, Data second)
        {
            if (first.Plus != second.Plus)//если числа разных знаков, то следует юзать разность
            {
                Data f;
                Data s;
                if (first > second)
                {
                    f = first.Copy();
                    s = second.Copy();

                }
                else
                {
                    f = second.Copy();
                    s = first.Copy();
                }
                s.Plus = !s.Plus;
                return f - s;
            } else
            {
                Data result = new Data();
                result.Plus = first.Plus;
                long reminder=0;
                int count=0;
                for (int i = 0; i < Math.Max(first.Count, second.Count); i++)
                {
                    result.Digits[i] = first.Digits[i] + second.Digits[i]+reminder;
                    reminder = result.Digits[i] / Base;
                    result.Digits[i] %= Base;
                    count++;
                }
                if (reminder != 0)
                {
                    if (count == N) throw new Exception("Результат вышел за пределы 25 знаков.");
                    result.Digits[count] = reminder;
                }
                return result;
            }
        }
        public static Data operator ++(Data input)
        {
            return input + One;
        }
        public static Data operator --(Data input)
        {
            return input - One;
        }
        //Унарный минус
        public static Data operator -(Data input)
        {
            Data result = input.Copy();
            result.Plus = !input.Plus;
            return result;
        }
        /*          Вычитание
         * Возможные случаи:
         *          1) Одинаковые знаки
         *              а)  first>=second - нормальное вычитание
         *              б) first<second - замена на -(second-first)
         *          2) Разные знаки -> Свести к сложению
         *               a-b=a+(-b)
         */
         /// <summary>
         /// Вычитание двух чисел типа <see cref="Data"/>
         /// </summary>
         /// <param name="first">Уменьшаемое типа <see cref="Data"/></param>
         /// <param name="second">Вычитаемое типа <see cref="Data"/></param>
         /// <returns>Разность типа <see cref="Data"/></returns>
        public static Data operator -(Data first, Data second)
        {
            if (first.Plus != second.Plus)
            {
                return first + (-second);
            }
            if (first < second) return -(second - first);
            int reminder = 0;
            Data result = first.Copy();
            for (int i = 0; i < first.Count; i++)
            {
                result.Digits[i] = result.Digits[i] - second.Digits[i] - reminder;
                if (result.Digits[i] < 0)
                {
                    reminder = 1;
                    result.Digits[i] += Base;
                }
            }
            return result;
        }
        //Умножение - обычное, столбиком
        /// <summary>
        /// Умножение двух чисел типа <see cref="Data"/>
        /// </summary>
        /// <param name="first">Первый множитель типа <see cref="Data"/></param>
        /// <param name="second">Второй множитель типа <see cref="Data"/></param>
        /// <returns>Произведение типа <see cref="Data"/></returns>
        public static Data operator *(Data first, Data second)
        {
            if (first.Count + second.Count - 1 > N) throw new Exception("Результат вышел за пределы 25 знаков");
            try
            {
                Data result = new Data();
                for (int i = 0; i < second.Count; i++)
                {
                    Data tempRes = new Data();
                    long reminder = 0;
                    for (int j = 0; j < first.Count; j++)
                    {
                        tempRes.Digits[i + j] = first.Digits[j] * second.Digits[i] + reminder;
                        reminder = tempRes.Digits[i + j] / Base;
                        tempRes.Digits[i + j] %= Base;
                    }
                    if (reminder > 0)
                    {
                        tempRes.Digits[tempRes.Count] = reminder;
                    }
                    result = result + tempRes;
                }
                result.Plus = !(first.Plus ^ second.Plus);
                return result;
            } 
            catch (IndexOutOfRangeException) { throw new Exception("Результат вышел за пределы 25 знаков"); }
        }
        /// <summary>
        /// Модуль данного числа типа  <see cref="Data"/> 
        /// </summary>
        /// <param name="input">Исходное число типа  <see cref="Data"/> </param>
        /// <returns>Модуль данного числа типа  <see cref="Data"/> </returns>
        public static Data Abs(Data input)
        {
            Data result = input.Copy();
            result.Plus = true;
            return result;
        }
        //Целочисленное деление длинных
        /// <summary>
        /// Целочисленное деление чисел типа <see cref="Data"/>
        /// </summary>
        /// <param name="first">Делимое типа <see cref="Data"/></param>
        /// <param name="second">Делитель типа <see cref="Data"/></param>
        /// <returns>Частное типа <see cref="Data"/></returns>
        public static Data operator /(Data first, Data second)
        {
            if (second == new Data()) throw new Exception("Деление на 0");
            Data right = first.Copy();
            Data left = new Data();
            left.Plus= !(first.Plus ^ second.Plus);
            right.Plus = left.Plus;
            if (first == new Data()) return left;
            if (Abs(first)<Abs(second)) return left;
            Data eps = new Data("1");
            while (Abs(right-left) > eps)
            {
                Data mid = (left + right) / 2;
                if (mid*second<first)
                {
                    left = mid;
                } else
                {
                    right = mid;
                }
            }
            if (left == right) return left;
            if (first - second * left < second * right - second) return left;
            else return right;
        }
        //Целочисленное деление на короткое число
        /// <summary>
        /// Целочисленное деление числа типа <see cref="Data"/> на число типа <see cref="int"/>
        /// </summary>
        /// <param name="first">Делимое типа <see cref="Data"/></param>
        /// <param name="second">Делитель типа <see cref="int"/></param>
        /// <returns>Частное типа <see cref="Data"/></returns>
        public static Data operator / (Data input,int div)
        {
            if (div >= Base) throw new Exception("Делитель - слишком длинное число.");
            Data result = input.Copy();
            long reminder = 0;
            for (int i=input.Count-1;i>=0;i--)
            {
                result.Digits[i] += reminder * Base;
                reminder = result.Digits[i] % div;
                result.Digits[i] /= div;
            }
            if ((double)reminder / div > 0.5) result++;
                return result;
        }
        //Деление короткого на длинное
        /// <summary>
        /// Целочисленное деление числа типа <see cref="long"/> на число типа <see cref="Data"/>
        /// </summary>
        /// <param name="first">Делимое типа <see cref="long"/></param>
        /// <param name="second">Делитель типа <see cref="Data"/></param>
        /// <returns>Частное типа <see cref="Data"/></returns>
        public static double operator / (long first, Data second)
        {
            double div = 0;
            for (int i = 0; i < second.Count; i++) div += second.Digits[i] * Math.Pow(Base, i);
            return first / div;
        }
        //Деление длинных
        /// <summary>
        /// Деление (нецелочисленное) чисел типа  <see cref="Data"/> 
        /// </summary>
        /// <param name="first">Делимое типа  <see cref="Data"/> </param>
        /// <param name="second">Делитель типа  <see cref="Data"/> </param>
        /// <returns>Частное типа  <see cref="double"/> </returns>
        public static double Divide (Data first, Data second)
        {
            if (second == new Data()) throw new Exception("Деление на 0");
            double result = 0;
            for (int i = 0; i < first.Count; i++)
            {
                result += (first.Digits[i] / second)* Math.Pow(Base,i);
            }
            if (first.Plus ^ second.Plus) result *= -1;
            return result;
        }
        //Остаток от деления
        /// <summary>
        /// Остаток от деления двух чисел типа <see cref="Data"/>
        /// </summary>
        /// <param name="first">Делимое типа  <see cref="Data"/> </param>
        /// <param name="second">Делитель типа  <see cref="Data"/> </param>
        /// <returns>Остаток типа <see cref="Data"/></returns>
        public static Data operator %(Data first, Data second)
        {
            Data del = first / second;
            del.Plus = true;
            Data f = first.Copy();
            f.Plus = true;
            Data s = second.Copy();
            s.Plus = true;
            Data res = f-s*del;
            if (!res.Plus) res += s;
            return res;
        }
        //Приведение
        /// <summary>
        /// Неявное приведение числа типа <see cref="double"/> к числу типа <see cref="Data"/>
        /// Работает точно при относительно небольших числах
        /// При больших числах работает с помощью бинарного поиска
        /// </summary>
        /// <param name="input"></param>
        public static implicit operator Data(double input)
        {
            return new Data(Math.Floor(input).ToString());
        }
        public override string ToString()
        {
            string result=Digits[Count-1].ToString();
            if (!Plus) result = '-' + result;
            for (int i = Count - 2; i >= 0; i--)
            {
                int tempBase = Base/10;
                while (Digits[i] / tempBase == 0 && tempBase>1)
                {
                    result += '0';
                    tempBase /= 10;
                }
                result += Digits[i].ToString();
            }
            return result;
        }
        public override bool Equals(object obj)
        {
            if (obj is Data)
            {
                Data d = obj as Data;
                return this == d;
            }
            return false;
        }
        public override int GetHashCode()
        {
            long Hash = 0;
            for (int i = 0; i < Digits.Length; i++) Hash += Digits[i].GetHashCode();
            return (int)Hash;
        }
    }
}
