using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace Functions
{
    /// <summary>
    /// <para>Непосредственно хранит длинные числа и содержит реализацию функций сложения, вычитания, умножения, целочисленного и нет деления</para>
    /// <para>Способ хранения: массив из <see cref="N"/> разрядов <see cref="Base"/>-ичной системы исчисления типа <see cref="long"/></para>
    /// </summary>
    public class Data : ICloneable, IComparable
    {
        #region Константы и свойства
        /// <summary>
        /// Количество используемых разрядов
        /// </summary>
        int Count
        {
            get
            {
                for (int i = N - 1; i > 0; i--)
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
        public static int Base = 100000;
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
        /// <summary>
        /// Представление минус нуля
        /// </summary>
        static Data NegZero
        {
            get
            {
                Data res = new Data();
                res.Plus = false;
                return res;
            }
        }
        #endregion Константы и свойства
        #region Конструкторы
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
                Input = Input.Remove(0, 1);
            }
            if (Input.Length > 25) throw new Exception("Слишком большая строка");
            int count = 0;
            while (Input.Length > 5)
            {
                Digits[count] = int.Parse(Input.Substring(Input.Length - 5));
                count++;
                Input = Input.Remove(Input.Length - 5);
            }
            Digits[count] = int.Parse(Input);
            ZeroFix();
        }
        /// <summary>
        /// Конструктор числа <see cref="Data"/> по числу <see cref="long"/>
        /// </summary>
        /// <param name="Input">Исходное число типа <see cref="long"/></param>
        public Data(long Input) : this(Input.ToString())
        {

        }
        #endregion Конструкторы
        #region Операторы сравнения
        /// <summary>
        /// Сравнение "меньше" для чисел типа <see cref="Data"/>
        /// </summary>
        /// <returns>Результат сравнения <see cref="bool"/></returns>
        public static bool operator <(Data first, Data second)
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
        /// <summary>
        /// Сравнение "больше" для чисел типа <see cref="Data"/>
        /// </summary>
        /// <returns>Результат сравнения <see cref="bool"/></returns>
        public static bool operator >(Data first, Data second)
        {
            return !(first < second) && !(first == second);
        }
        /// <summary>
        /// Сравнение на равенство для чисел типа <see cref="Data"/>
        /// </summary>
        /// <returns>Результат сравнения <see cref="bool"/></returns>
        public static bool operator ==(Data first, Data second)
        {
            if (first.Plus != second.Plus || first.Count != second.Count)
            {
                return false;
            }
            for (int i = 0; i < first.Count; i++) if (first.Digits[i] != second.Digits[i]) return false;
            return true;
        }
        /// <summary>
        /// Сравнение на неравенство для чисел типа <see cref="Data"/>
        /// </summary>
        /// <returns>Результат сравнения <see cref="bool"/></returns>
        public static bool operator !=(Data first, Data second)
        {
            return !(first == second);
        }
        /// <summary>
        /// Сравнение "меньше или равно" для чисел типа <see cref="Data"/>
        /// </summary>
        /// <returns>Результат сравнения <see cref="bool"/></returns>
        public static bool operator <=(Data first, Data second)
        {
            return !(first > second);
        }
        /// <summary>
        /// Сравнение "больше или равно" для чисел типа <see cref="Data"/>
        /// </summary>
        /// <returns>Результат сравнения <see cref="bool"/></returns>
        public static bool operator >=(Data first, Data second)
        {
            return !(first > second);
        }
        #endregion Операторы сравнения
        #region Арифметические действия
        /// <summary>
        /// Сложение двух чисел типа <see cref="Data"/>
        /// </summary>
        /// <remarks> Сложение
        ///  Возможные случаи:
        ///     1) Одинаковые знаки -> Выполняется обычное сложение, знак результата = знак входных чисел
        ///     2) Разные знаки -> Следует привести к вычитанию 
        ///         a+b = a-(-b) = b-(-a)
        ///         Наименьший следует использовать в качестве вычитаемого!</remarks>
        /// <param name="first">Первое слагаемое типа <see cref="Data"/></param>
        /// <param name="second">Второе слагаемое типа <see cref="Data"/></param>
        /// <returns>Сумма слагаемых типа <see cref="Data"/></returns>
        public static Data operator +(Data first, Data second)
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
            }
            else
            {
                Data result = new Data();
                result.Plus = first.Plus;
                long reminder = 0;
                int count = 0;
                for (int i = 0; i < Math.Max(first.Count, second.Count); i++)
                {
                    result.Digits[i] = first.Digits[i] + second.Digits[i] + reminder;
                    reminder = result.Digits[i] / Base;
                    result.Digits[i] %= Base;
                    count++;
                }
                if (reminder != 0)
                {
                    if (count == N) throw new Exception("Результат вышел за пределы 25 знаков.");
                    result.Digits[count] = reminder;
                }
                result.ZeroFix();
                return result;
            }
        }
        /// <summary>
        /// Инкремент числа типа <see cref="Data"/>
        /// </summary>
        public static Data operator ++(Data input)
        {
            return input + One;
        }
        /// <summary>
        /// Декремент числа типа <see cref="Data"/>
        /// </summary>
        public static Data operator --(Data input)
        {
            return input - One;
        }
        /// <summary>
        ///Унарный минус для числа типа <see cref="Data"/>
        /// </summary>
        public static Data operator -(Data input)
        {
            Data result = input.Copy();
            result.Plus = !input.Plus;
            return result;
        }
        /// <summary>
        /// Вычитание двух чисел типа <see cref="Data"/>
        /// </summary>
        /// <remarks>        Вычитание
        /// Возможные случаи:
        ///          1) Одинаковые знаки
        ///             а)  first больше (или равно) second - нормальное вычитание
        ///             б) first меньше second - замена на -(second-first)
        ///          2) Разные знаки -> Свести к сложению
        ///               a-b=a+(-b)</remarks>
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
                else
                {
                    reminder = 0;
                }
            }
            result.ZeroFix();
            return result;
        }
        /// <summary>
        /// Умножение двух чисел типа <see cref="Data"/>
        /// </summary>
        /// <remarks>Умножение - обычное, столбиком</remarks>
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
                    int j;
                    for (j = 0; j < first.Count; j++)
                    {
                        tempRes.Digits[i + j] = first.Digits[j] * second.Digits[i] + reminder;
                        reminder = tempRes.Digits[i + j] / Base;
                        tempRes.Digits[i + j] %= Base;
                    }
                    if (reminder > 0)
                    {
                        tempRes.Digits[i + j] = reminder;
                    }
                    result = result + tempRes;
                }
                result.Plus = !(first.Plus ^ second.Plus);
                result.ZeroFix();
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
        /// <summary>
        /// Целочисленное деление чисел типа <see cref="Data"/>
        /// </summary>
        /// <param name="first">Делимое типа <see cref="Data"/></param>
        /// <param name="second">Делитель типа <see cref="Data"/></param>
        /// <returns>Частное типа <see cref="Data"/></returns>
        public static Data operator /(Data first, Data second)
        {
            if (second == new Data()) throw new Exception("Деление на 0");
            if (second == Data.One) return first;
            Data right = (Abs(first.Copy()));
            if (right < MaxValue) right++;
            Data left = new Data();
            if (first == new Data()) return left;
            if (Abs(first) < Abs(second)) return left;
            Data eps = One;
            while (Abs(right - left) > eps)
            {
                Data mid = left / 2 + right / 2;
                if (left.Digits[0] % 2 == 1 && right.Digits[0] % 2 == 1) mid++;
                if (Abs(mid * second) <= Abs(first))
                {
                    left = mid;
                }
                else
                {
                    right = mid;
                }
            }
            left.Plus = !(first.Plus ^ second.Plus);
            left.ZeroFix();
            return left;
        }
        /// <summary>
        /// Целочисленное деление числа типа <see cref="Data"/> на число типа <see cref="int"/> с округлением
        /// </summary>
        /// <param name="input">Делимое типа <see cref="Data"/></param>
        /// <param name="div">Делитель типа <see cref="int"/></param>
        /// <returns>Частное типа <see cref="Data"/></returns>
        public static Data operator /(Data input, int div)
        {
            if (div >= Base) throw new Exception("Делитель - слишком длинное число.");
            if (div == 0) throw new DivideByZeroException();
            Data result = input.Copy();
            long reminder = 0;
            for (int i = input.Count - 1; i >= 0; i--)
            {
                result.Digits[i] += reminder * Base;
                reminder = result.Digits[i] % div;
                result.Digits[i] /= div;
            }
            if ((double)reminder / div > 0.5) result++;
            result.ZeroFix();
            return result;
        }
        /// <summary>
        /// Целочисленное деление числа типа <see cref="long"/> на число типа <see cref="Data"/>
        /// </summary>
        /// <param name="first">Делимое типа <see cref="long"/></param>
        /// <param name="second">Делитель типа <see cref="Data"/></param>
        /// <returns>Частное типа <see cref="Data"/></returns>
        public static double operator /(long first, Data second)
        {
            if (second == new Data()) throw new DivideByZeroException();
            double div = 0;
            for (int i = 0; i < second.Count; i++) div += second.Digits[i] * Math.Pow(Base, i);
            return first / div;
        }
        /// <summary>
        /// Деление (нецелочисленное) чисел типа  <see cref="Data"/> 
        /// </summary>
        /// <param name="first">Делимое типа  <see cref="Data"/> </param>
        /// <param name="second">Делитель типа  <see cref="Data"/> </param>
        /// <returns>Частное типа  <see cref="double"/> </returns>
        public static double Divide(Data first, Data second)
        {
            if (second == new Data()) throw new Exception("Деление на 0");
            double result = 0;
            for (int i = 0; i < first.Count; i++)
            {
                result += (first.Digits[i] / second) * Math.Pow(Base, i);
            }
            if (first.Plus ^ second.Plus) result *= -1;
            return result;
        }
        /// <summary>
        /// Остаток от деления двух чисел типа <see cref="Data"/>
        /// </summary>
        /// <param name="first">Делимое типа  <see cref="Data"/> </param>
        /// <param name="second">Делитель типа  <see cref="Data"/> </param>
        /// <returns>Остаток типа <see cref="Data"/></returns>
        public static Data operator %(Data first, Data second)
        {
            Data del = first / second;
            Data res = first - second * del;
            res.ZeroFix();
            return res;
        }
        /// <summary>
        /// Неявное приведение числа типа <see cref="double"/> к числу типа <see cref="Data"/>
        /// Работает точно при относительно небольших числах
        /// При больших числах работает с помощью бинарного поиска
        /// </summary>
        /// <param name="input"></param>
        public static implicit operator Data(double input)
        {
            if (input < long.MaxValue)
            {
                long l = (long)Math.Ceiling(input);
                if (Math.Abs(l / input - 1) > Math.Abs((l - 1) / input - 1)) l--;
                return new Data(l.ToString());
            }
            int maxBase = 0;
            while (input > Math.Pow(Base, maxBase)) maxBase++;
            if (maxBase > N) throw new Exception("Неожиданно большое число");
            Data left = new Data();
            Data right = MaxValue;
            while (Abs(left - right) > One)
            {
                Data middle = left / 2 + right / 2;
                if (Divide(middle, One) == input) return middle;
                if (Divide(middle, One) < input) left = middle;
                else right = middle;
            }
            Data result = (left + right) / 2;
            result.ZeroFix();
            return result;
        }
        #endregion Действия
        #region Различные прочие функции
        /// <summary>
        /// Костыль для удаления минуса у нуля
        /// </summary>
        void ZeroFix()
        {
            if (this == NegZero) Plus = true;
        }
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
        /// Функция колирования из интерфеса IClonable
        /// </summary>
        /// <returns>Клон данного объекта типа <see cref="Data"/>, представленный как <see cref="object"/></returns>
        public object Clone()
        {
            return Copy();
        }
        /// <summary>
        /// Стандартная функция строкового представления объекта
        /// </summary>
        /// <returns>Строка <see cref="string"/>, представляющая данный объект <see cref="Data"/></returns>
        public override string ToString()
        {
            string result = Digits[Count - 1].ToString();
            if (!Plus) result = '-' + result;
            for (int i = Count - 2; i >= 0; i--)
            {
                int tempBase = Base / 10;
                while (Digits[i] / tempBase == 0 && tempBase > 1)
                {
                    result += '0';
                    tempBase /= 10;
                }
                result += Digits[i].ToString();
            }
            return result;
        }
        /// <summary>
        /// Стандартная функция сравнения объектов
        /// </summary>
        /// <param name="obj">Объект сравнения</param>
        /// <returns>Результат сравнения типа <see cref="bool"/></returns>
        public override bool Equals(object obj)
        {
            if (obj is Data)
            {
                Data d = obj as Data;
                return this == d;
            }
            return false;
        }
        /// <summary>
        /// Стандартная функция получения хэш-кода объекта
        /// </summary>
        /// <returns>Хэш-код данного объекта <see cref="Data"/> в виде числа <see cref="int"/></returns>
        public override int GetHashCode()
        {
            long Hash = 0;
            for (int i = 0; i < Digits.Length; i++) Hash += Digits[i].GetHashCode();
            return (int)Hash;
        }
        /// <summary>
        /// Стандартная функция сравнения объектов интерфейса IComparable
        /// </summary>
        /// <param name="obj">Объект сравнения</param>
        /// <returns><para>Результат сравнения:</para>
        /// <para>Меньше нуля        Данный экземпляр предшествует параметру obj в порядке сортировки.</para>
        /// <para>Нуль  Этот экземпляр выполняется в той же позиции в порядке сортировки, что obj.</para>
        /// <para>Больше нуля Данный экземпляр следует за параметром obj в порядке сортировки.</para></returns>
        public int CompareTo(object obj)
        {
            if (obj is Data)
            {
                Data temp = obj as Data;
                if (this > temp) return 1;
                if (this == temp) return 0;
                return -1;
            }
            else
            {
                throw new ArgumentException();
            }
        }
        #endregion Различные прочие функции
    }
}
