using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Functions
{
    class Data
    {
        const int N = 5;
        uint[] Digits = new uint[N];
        bool Plus = true;
        const uint Base = 100000;
        public Data(string Input)
        {
            if (Input.Length > 26) throw new Exception("Слишком большая строка");
            Regex check = new Regex("^-?[0-9]+$");
            if (!check.IsMatch(Input)) throw new Exception("Неверное представление");
            throw new NotImplementedException();
        }
        public static bool operator < (Data first, Data second)
        {
            throw new NotImplementedException();
        }
        public static bool operator >(Data first, Data second)
        {
            throw new NotImplementedException();
        }
        public Data Copy()
        {
            throw new NotImplementedException();
        }
        public static Data operator + (Data first, Data second)
        {
            if (first.Plus != second.Plus)
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
            throw new NotImplementedException();
        }
        public static Data operator -(Data first, Data second)
        {
            throw new NotImplementedException();
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
       
        public static double operator %(Data first, Data second)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            throw new NotImplementedException();
            return base.ToString();
        }
    }
}
