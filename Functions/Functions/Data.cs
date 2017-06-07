using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    class Data
    {
        const int N = 5;
        uint[] Digits = new uint[N];
        bool Plus = true;
        const uint Base = 100000;
        public static Data operator + (Data first, Data second)
        {
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
