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
            Console.WriteLine(d1);
            Data d2 = new Data("1");
            Console.WriteLine(d2);
            Data d3 = new Data("-1");
            Console.WriteLine(d3);
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
            Data d7 = new Data("9999999999999999999999999");
            Console.WriteLine(d7);
            try
            {
                Data d8 = new Data("99999999999999999999999999");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Data d9 = new Data("-9999999999999999999999999");
            Console.WriteLine(d9);
            Data d10 = d9.Copy();
            Console.WriteLine(d10);

            Console.Read();
        }
    }
}
