using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*
 * Написанные операции: + -  * / /цел %
 */

namespace Functions
{
    public class Data
    {
        int Count
        {
            get
            { for (int i = N - 1; i > 0; i--)
                    if (Digits[i] != 0) return i + 1;
                return 1;
            }
        }
        const int N = 5;
        long[] Digits = new long[N];
        bool Plus = true;
        const int Base = 100000;
        public Data() //инициализируется число 0
        {
            
        }
        public Data(string Input) //инициализируется длинное число по строке
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
        public Data Copy()
        {
            Data result = new Data();
            for (int i = 0; i < Digits.Length; i++) result.Digits[i] = Digits[i];
            result.Plus = Plus;
            return result;
        }
        public static Data MaxValue
        {
            get
            {
                return new Data("9999999999999999999999999");
            }
        }
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
        public static Data Abs(Data input)
        {
            Data result = input.Copy();
            result.Plus = true;
            return result;
        }
        //Целочисленное деление длинных
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
        public static double operator / (long first, Data second)
        {
            double div = 0;
            for (int i = 0; i < second.Count; i++) div += second.Digits[i] * Math.Pow(Base, i);
            return first / div;
        }
        //Деление длинных
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
        public static implicit operator Data(double input)
        {
            //следует проверить, может сломаться
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
            while (Abs(left-right)>One)
            {
                Data middle = left/2 + right/2;
                if (Divide(middle, One) == input) return middle;
                if (Divide(middle, One) < input) left = middle;
                else right = middle;
            }
            return (left + right) / 2;
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
