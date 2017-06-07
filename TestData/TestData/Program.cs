using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functions;

namespace TestData
{
    class Program
    {
        static void Main(string[] args)
        {
            Data d1 = new Data();
            Data d2 = new Data("1");
            Data d3 = new Data("-1");
            try {Data d4 = new Data("--1");}
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try {Data d5 = new Data("");}
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try { Data d6 = new Data("ABC");}
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
