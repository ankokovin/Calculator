using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*
 * Написанные операции: + -
 * Написать: * / /цел %
 */ 

namespace Functions
{
    public class Data
    {
        int Count;
        const int N = 5;
        uint[] Digits = new uint[N];
        bool Plus = true;
        const uint Base = 100000;
        public Data()
        {
            Count = 1;
        }
        public Data(string Input)
        {
            if (Input.Length > 26) throw new Exception("Слишком большая строка");
            Regex check = new Regex("^-?[0-9]+$");
            if (!check.IsMatch(Input)) throw new Exception("Неверное представление");
            throw new NotImplementedException();
        }
        public static bool operator < (Data first, Data second)
        {
            if (first.Plus != second.Plus)
            {
                if (first.Plus) return false;
                else return true;
            }
            if (first.Count > second.Count) return false;
            if (second.Count > first.Count) return true;
            for (int i = first.Count - 1; i >= 0; i++)
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
        public Data Copy()
        {
            throw new NotImplementedException();
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
                uint reminder=0;
                for (int i = 0; i < Math.Max(first.Count, second.Count); i++)
                {
                    result.Digits[i] = first.Digits[i] + second.Digits[i]+reminder;
                    reminder = result.Digits[i] / Base;
                    result.Digits[i] %= Base;
                }
                result.Count = Math.Max(first.Count, second.Count);
                if (reminder != 0)
                {
                    if (result.Count == N) throw new Exception("Результат вышел за пределы 25 знаков.");
                    result.Digits[result.Count] = reminder;
                    result.Count++;
                }
                return result;
            }
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
            uint reminder = 0;
            Data result = first.Copy();
            for (int i = first.Count - 1; i <= 0; i++)
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
        public static Data operator *(Data first, Data second)
        {
            throw new NotImplementedException();
        }
        public static Data operator /(Data first, Data second)
        {
            throw new NotImplementedException();
        }
        public static double Divide (Data first, Data second)
        {
            throw new NotImplementedException();
        }
       
        public static Data operator %(Data first, Data second)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            string result=Digits[Count-1].ToString();
            if (!Plus) result = '-' + result;
            for (int i = Count - 2; i >= 0; i++)
            {
                uint tempBase = Base/10;
                while (Digits[i] / tempBase == 0 && tempBase>1)
                {
                    result += '0';
                    tempBase /= 10;
                }
                result += Digits[i].ToString();
            }
            return result;
        }
    }
}
