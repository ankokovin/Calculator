using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functions;

namespace TestData
{
    //TO DO: Тест умножения и цел. деления
    //       Тест деления и приведения
    class Program
    {
        static void Main(string[] args)
        {
            #region Тест конструтора+Copy

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
            Data d11 = new Data("-1000001");
            Console.WriteLine(d11);
            Data d12 = new Data("-0");
            Console.WriteLine(d12);
            Console.ReadLine();

            #endregion Тест конструтора+Copy
            #region Тест сравнений
            Console.Clear();
            Console.WriteLine("0 == 0" + (new Data() == new Data()));
            Console.WriteLine("0 > 0" + (new Data() > new Data()));
            Console.WriteLine("0 < 0" + (new Data() < new Data()));
            Console.WriteLine("-1 < 1" + (new Data("-1") < new Data("1")));
            Console.WriteLine("-1 == 1"+(new Data("-1") == new Data("1")));
            Console.WriteLine("-1 > 1"+(new Data("-1") > new Data("1")));
            Console.WriteLine("1 < -1"+(new Data("1") < new Data("-1")));
            Console.WriteLine("1 == -1"+(new Data("1") == new Data("-1")));
            Console.WriteLine("1 > -1" + (new Data("1") > new Data("-1")));
            Console.WriteLine("100000 > 1" + (new Data("100000") > new Data("1")));
            Console.WriteLine("100000 == 1" + (new Data("100000") == new Data("1")));
            Console.WriteLine("100000 < 1" + (new Data("100000") < new Data("1")));
            Console.WriteLine("1>100000"+(new Data("1") > new Data("100000")));
            Console.WriteLine("1>100000" + (new Data("1") == new Data("100000")));
            Console.WriteLine("1>100000" + (new Data("1") < new Data("100000")));
            Console.WriteLine("9999999999999999999999999 == 9999999999999999999999999" +
                ( new Data("9999999999999999999999999") == new Data("9999999999999999999999999")));
            Console.WriteLine("9999999999999999999999999 > 9999999999999999999999999" +
                (new Data("9999999999999999999999999") > new Data("9999999999999999999999999")));
            Console.WriteLine("9999999999999999999999999 < 9999999999999999999999999" +
                (new Data("9999999999999999999999999") < new Data("9999999999999999999999999")));
            Console.WriteLine("9999999999999999999999998 == 9999999999999999999999999" +
                (new Data("9999999999999999999999998") == new Data("9999999999999999999999999")));
            Console.WriteLine("9999999999999999999999998 > 9999999999999999999999999" +
                (new Data("9999999999999999999999998") > new Data("9999999999999999999999999")));
            Console.WriteLine("9999999999999999999999998 < 9999999999999999999999999" +
                (new Data("9999999999999999999999998") < new Data("9999999999999999999999999")));
            Console.WriteLine("9999999999990999999999999 == 9999999999999999999999999" +
                (new Data("9999999999990999999999999") == new Data("9999999999999999999999999")));
            Console.WriteLine("9999999999990999999999999 > 9999999999999999999999999" +
                (new Data("9999999999990999999999999") > new Data("9999999999999999999999999")));
            Console.WriteLine("9999999999990999999999999 < 9999999999999999999999999" +
                (new Data("9999999999990999999999999") < new Data("9999999999999999999999999")));
            Console.ReadLine();
            #endregion Тест сравнений
            #region Тест сложения и вычитания
            Console.Clear();

            Console.WriteLine("0+0="+(new Data() + new Data()));
            Console.WriteLine("0+10="+(new Data() + new Data("10")));
            Console.WriteLine("10+0="+(new Data("10") + new Data()));
            Console.WriteLine("1000000000+1=" + (new Data("1000000000") + new Data("1")));
            Console.WriteLine("9+1="+(new Data("9") + new Data("1")));
            Console.WriteLine("109999999999+1=" + (new Data("109999999999") + new Data("1")));
            Console.WriteLine("-10+(-100)="+(new Data("-10") + new Data("-100")));
            try { Data s = new Data("9999999999999999999999999") + new Data("1"); }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("10+(-10)="+(new Data("10") + new Data("-10")));
            Console.WriteLine("99+(-9)=" + (new Data("99") + new Data("-9")));
            Console.WriteLine("9+(-99)=" + (new Data("9") + new Data("-99")));
            Console.WriteLine("-9+99=" + (new Data("-9") + new Data("99")));
            Console.WriteLine("-99+9=" + (new Data("-99") + new Data("9")));
            Console.WriteLine("0+(-0)=" + (new Data() + new Data("-0")));
            Console.WriteLine("0-0=" + (new Data() - new Data()));
            Console.WriteLine("0-10=" + (new Data() - new Data("10")));
            Console.WriteLine("10-0=" + (new Data("10") - new Data("0")));
            Console.WriteLine("100000000-1=" + (new Data("100000000") - new Data("1")));
            Console.WriteLine("1-100000000=" + (new Data("1") - new Data("100000000")));
            Console.WriteLine("-10-(-100)=" + (new Data("-10") - new Data("-100")));
            Console.WriteLine("10-(-10)=" + (new Data("10") - new Data("-10")));
            Console.WriteLine("-10-10=" + (new Data("-10") - new Data("10")));

            Console.ReadLine();
            #endregion Тест сложения и вычитания
            #region Тест умножения 
            Console.Clear();

            Console.WriteLine("0*0=" + (new Data() * new Data()));
            Console.WriteLine("1000000*0=" + (new Data("1000000") * new Data()));
            Console.WriteLine("0*1000000=" + (new Data() * new Data("1000000")));
            Console.WriteLine("1000000*1=" + (new Data("1000000") * new Data("1")));
            Console.WriteLine("1*1000000=" + (new Data("1") * new Data("1000000")));
            Console.WriteLine("1000*1000=" + (new Data("1000") * new Data("1000")));
            Console.WriteLine("10000001*10000001=" + (new Data("10000001") * new Data("10000001")));
            Console.WriteLine("-1*1000=" + (new Data("-1") * new Data("1000")));
            Console.WriteLine("1000*(-1)=" + (new Data("1000") * new Data("-1")));
            Console.WriteLine("1234567890*987654321=" + (new Data("1234567890") * new Data("987654321")) + " "
                + ((new Data("1234567890") * new Data("987654321")) == new Data("1219326311126352690")));
            Console.WriteLine("-1234567890*987654321=" + (new Data("-1234567890") * new Data("987654321")) + " "
               + ((new Data("-1234567890") * new Data("987654321")) == new Data("-1219326311126352690")));
            Console.WriteLine("-1234567890*(-987654321)=" + (new Data("-1234567890") * new Data("-987654321")) + " "
               + ((new Data("-1234567890") * new Data("-987654321")) == new Data("1219326311126352690")));

            Console.ReadLine();
            #endregion Тест умножения 
            #region Тест цел. деления
            #endregion Тест цел. деления
            #region Тест деления и приведения
            #endregion Тест деления и приведения
        }
    }
}
