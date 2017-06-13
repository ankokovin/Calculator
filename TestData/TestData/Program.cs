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
            #region Основные тесты
            #region Тест конструкторов+Copy
            Console.WriteLine("Тест конструктора+Copy");
            Console.WriteLine("По строке");
            Data d1 = new Data();
            Console.WriteLine(d1);
            d1 = Data.One;
            Console.WriteLine(d1);
            d1 = new Data("-1");
            Console.WriteLine(d1);
            Console.WriteLine("Создание по строке --1");
            try { Data d4 = new Data("--1"); }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Создание по пустой строке");
            try { Data d5 = new Data(""); }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Создание по строке ABC");
            try { Data d6 = new Data("ABC"); }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            d1 = new Data("9999999999999999999999999");
            Console.WriteLine(d1);
            Console.WriteLine("Создание по строке 99999999999999999999999999 (26 девяток)");
            try
            {
                Data d8 = new Data("99999999999999999999999999");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            d1 = new Data("-1000001");
            Console.WriteLine(d1);
            d1 = new Data("-0");
            Console.WriteLine(d1);
            Console.WriteLine("По числу");
            Console.WriteLine(new Data(0));
            Console.WriteLine(new Data(-1));
            Console.WriteLine(new Data(long.MaxValue));
            Console.WriteLine(new Data(long.MinValue));
            Console.WriteLine("Копирование");
            d1 = new Data("-9999999999999999999999999");
            Console.WriteLine(d1);
            Data d10 = d1.Copy();
            Console.WriteLine(d10);
            Console.WriteLine("Клонирование");
            object d11 = d1.Clone();
            Console.WriteLine(d11);
            Console.ReadLine();
            #endregion Тест конструтора+Copy
            #region Тест сравнений
            Console.Clear();
            Console.WriteLine("Тест сравнений");
            Console.WriteLine("0 == 0" + (new Data() == new Data()) + " Ожидалось: True");
            Console.WriteLine("0 > 0" + (new Data() > new Data()) + " Ожидалось: False");
            Console.WriteLine("0 < 0" + (new Data() < new Data()) + " Ожидалось: False");
            Console.WriteLine("-1 < 1" + (new Data(-1) < Data.One) + " Ожидалось: True");
            Console.WriteLine("-1 == 1" + (new Data(-1) == Data.One) + " Ожидалось: False");
            Console.WriteLine("-1 > 1" + (new Data(-1) > Data.One) + " Ожидалось: False");
            Console.WriteLine("1 < -1" + (Data.One < new Data(-1)) + " Ожидалось: False");
            Console.WriteLine("1 == -1" + (Data.One == new Data(-1)) + " Ожидалось: False");
            Console.WriteLine("1 > -1" + (Data.One > new Data(-1)) + " Ожидалось: True ");
            Console.WriteLine("100000 > 1" + (new Data(100000) > Data.One) + " Ожидалось: True");
            Console.WriteLine("100000 == 1" + (new Data(100000) == Data.One) + " Ожидалось: False");
            Console.WriteLine("100000 < 1" + (new Data(100000) < Data.One) + " Ожидалось: False");
            Console.WriteLine("1>100000" + (Data.One > new Data(100000)) + " Ожидалось: False");
            Console.WriteLine("1==100000" + (Data.One == new Data(100000)) + " Ожидалось: False");
            Console.WriteLine("1<100000" + (Data.One < new Data(100000)) + " Ожидалось: True");
            Console.WriteLine("9999999999999999999999999 == 9999999999999999999999999" +
                (new Data("9999999999999999999999999") == new Data("9999999999999999999999999")) + " Ожидалось: True");
            Console.WriteLine("9999999999999999999999999 > 9999999999999999999999999" +
                (new Data("9999999999999999999999999") > new Data("9999999999999999999999999")) + " Ожидалось: False");
            Console.WriteLine("9999999999999999999999999 < 9999999999999999999999999" +
                (new Data("9999999999999999999999999") < new Data("9999999999999999999999999")) + " Ожидалось: False");
            Console.WriteLine("9999999999999999999999998 == 9999999999999999999999999" +
                (new Data("9999999999999999999999998") == new Data("9999999999999999999999999")) + " Ожидалось: False");
            Console.WriteLine("9999999999999999999999998 > 9999999999999999999999999" +
                (new Data("9999999999999999999999998") > new Data("9999999999999999999999999")) + " Ожидалось: False");
            Console.WriteLine("9999999999999999999999998 < 9999999999999999999999999" +
                (new Data("9999999999999999999999998") < new Data("9999999999999999999999999")) + " Ожидалось: True ");
            Console.WriteLine("9999999999990999999999999 == 9999999999999999999999999" +
                (new Data("9999999999990999999999999") == new Data("9999999999999999999999999")) + " Ожидалось: False");
            Console.WriteLine("9999999999990999999999999 > 9999999999999999999999999" +
                (new Data("9999999999990999999999999") > new Data("9999999999999999999999999")) + " Ожидалось: False");
            Console.WriteLine("9999999999990999999999999 < 9999999999999999999999999" +
                (new Data("9999999999990999999999999") < new Data("9999999999999999999999999")) + " Ожидалось: True ");
            Console.ReadLine();
            #endregion Тест сравнений
            #region Тест сложения и вычитания
            Console.Clear();
            Console.WriteLine("Тест сложения и вычитания");
            Data inc = new Data(-1);
            Console.WriteLine("++(-1)=" + (++inc) + " Ожидалось:  0");
            Console.WriteLine("++0=" + (++inc) + " Ожидалось:  1");
            Console.WriteLine("++1=" + (++inc) + " Ожидалось:  2");
            inc = new Data(9999);
            Console.WriteLine("++9999=" + (++inc) + " Ожидалось:  10000");
            Console.WriteLine("0+0=" + (new Data() + new Data()) + " Ожидалось:  0");
            Console.WriteLine("0+10=" + (new Data() + new Data(10)) + " Ожидалось:  10");
            Console.WriteLine("10+0=" + (new Data(10) + new Data()) + " Ожидалось:  10");
            Console.WriteLine("1000000000+1=" + (new Data(1000000000) + Data.One) + " Ожидалось: 1000000001");
            Console.WriteLine("9+1=" + (new Data(9) + Data.One) + " Ожидалось:  10");
            Console.WriteLine("109999999999+1=" + (new Data("109999999999") + Data.One) + " Ожидалось: 110000000000");
            Console.WriteLine("-10+(-100)=" + (new Data(-10) + new Data(-100)) + " Ожидалось: -110");
            Console.WriteLine("Попытка подсчитать 9999999999999999999999999 + 1 (25 девяток + 1)");
            try { Data s = Data.MaxValue + Data.One; }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("999999999999999999999999+1=" + (new Data("999999999999999999999999") + Data.One) + " Ожидалось: 1000000000000000000000000");
            Console.WriteLine("10+(-10)=" + (new Data(10) + new Data(-10)) + " Ожидалось: 0");
            Console.WriteLine("99+(-9)=" + (new Data(99) + new Data(-9)) + " Ожидалось: 90");
            Console.WriteLine("9+(-99)=" + (new Data(9) + new Data(-99)) + " Ожидалось: -90");
            Console.WriteLine("-9+99=" + (new Data(-9) + new Data(99)) + " Ожидалось: 90");
            Console.WriteLine("-99+9=" + (new Data(-99) + new Data(9)) + " Ожидалось: -90");
            Console.WriteLine("0-0=" + (new Data() - new Data()) + " Ожидалось: 0");
            Console.WriteLine("0-10=" + (new Data() - new Data(10)) + " Ожидалось: -10");
            Console.WriteLine("10-0=" + (new Data(10) - new Data()) + " Ожидалось: 10");
            Console.WriteLine("100000000-1=" + (new Data(100000000) - Data.One) + " Ожидалось: 99999999");
            Console.WriteLine("1-100000000=" + (Data.One - new Data(100000000)) + " Ожидалось: -99999999");
            Console.WriteLine("-10-(-100)=" + (new Data(-10) - new Data(-100)) + " Ожидалось: 90");
            Console.WriteLine("10-(-10)=" + (new Data(10) - new Data(-10)) + " Ожидалось: 20");
            Console.WriteLine("-10-10=" + (new Data(-10) - new Data(10)) + " Ожидалось: -20");

            Console.ReadLine();
            #endregion Тест сложения и вычитания
            #region Тест умножения 
            Console.Clear();
            Console.WriteLine("Тест умножения");
            Console.WriteLine("0*0=" + (new Data() * new Data()) + " Ожидалось: 0");
            Console.WriteLine("1000000*0=" + (new Data(1000000) * new Data()) + " Ожидалось: 0");
            Console.WriteLine("0*1000000=" + (new Data() * new Data(1000000)) + " Ожидалось: 0");
            Console.WriteLine("1000000*1=" + (new Data(1000000) * Data.One) + " Ожидалось: 1000000");
            Console.WriteLine("1*1000000=" + (Data.One * new Data(1000000)) + " Ожидалось: 1000000");
            Console.WriteLine("1000*1000=" + (new Data(1000) * new Data(1000)) + " Ожидалось: 1000000");
            Console.WriteLine("10000001*10000001=" + (new Data(10000001) * new Data(10000001)) + " Ожидалось: 100000020000001");
            Console.WriteLine("-1*1000=" + (new Data(-1) * new Data(1000)) + " Ожидалось: -1000");
            Console.WriteLine("1000*(-1)=" + (new Data(1000) * new Data(-1)) + " Ожидалось: -1000");
            Console.WriteLine("1234567890*987654321=" + (new Data(1234567890) * new Data(987654321)) + " "
                + ((new Data(1234567890) * new Data(987654321)) == new Data("1219326311126352690")) + " Ожидалось: 1219326311126352690");
            Console.WriteLine("-1234567890*987654321=" + (new Data(-1234567890) * new Data(987654321)) + " "
               + ((new Data(-1234567890) * new Data("987654321")) == new Data("-1219326311126352690")) + " Ожидалось: -1219326311126352690");
            Console.WriteLine("-1234567890*(-987654321)=" + (new Data(-1234567890) * new Data(-987654321)) + " "
               + ((new Data(-1234567890) * new Data(-987654321)) == new Data("1219326311126352690")) + " Ожидалось: 1219326311126352690");
            Console.WriteLine("Попытка подсчитать 9999999999999999999999999*10 (25 девяток * 10)");
            try { Console.WriteLine("9999999999999999999999999*10=" + (Data.MaxValue * new Data(10))); }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("Попытка подсчитать 99999999999999999999*1000000 (20 девяток * 1000000)");
            try
            {
                Console.WriteLine("99999999999999999999*1000000=" +
              (new Data("99999999999999999999") * new Data(1000000)));
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("1111111111111111111111111*9=" + (new Data("1111111111111111111111111") * new Data(9)) + " Ожидалось: 9999999999999999999999999");
            Console.WriteLine("Попытка подсчитать 1111111111111111111111111*10 (25 едениц * 10");
            try
            {
                Console.WriteLine("1111111111111111111111111*10=" +
                    (new Data("1111111111111111111111111") * new Data(10)));
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.ReadLine();
            #endregion Тест умножения 
            #region Тест цел. деления
            Console.Clear();
            Console.WriteLine("Тест цел. деления");
            Console.WriteLine("Попытка деления на 0");
            try
            {
                Console.WriteLine("1/0=" + (Data.One / new Data()));
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("0/1=" + (new Data() / Data.One) + " Ожидалось: 0");
            Console.WriteLine("0/(-1)=" + (new Data() / new Data(-1)) + " Ожидалось: 0");
            Console.WriteLine("12/33=" + (new Data(12) / new Data(33)) + " Ожидалось: 0");
            Console.WriteLine("-12/33=" + (new Data(-12) / new Data(33)) + " Ожидалось: 0");
            Console.WriteLine("12/(-33)=" + (new Data(12) / new Data(-33)) + " Ожидалось: 0");
            Console.WriteLine("-12/(-33)=" + (new Data(-12) / new Data(-33)) + " Ожидалось: 0");
            Console.WriteLine("121/11=" + (new Data(121) / new Data(11)) + " Ожидалось: 11");
            Console.WriteLine("-121/11=" + (new Data(-121) / new Data(11)) + " Ожидалось: -11");
            Console.WriteLine("121/(-11)=" + (new Data(121) / new Data(-11)) + " Ожидалось: -11");
            Console.WriteLine("-121/(-11)=" + (new Data(-121) / new Data(-11)) + " Ожидалось: 11");
            Console.WriteLine("9999999999/1=" + (new Data(9999999999) / Data.One) + " Ожидалось: 9999999999");
            Console.WriteLine("9999999999/9999999999=" + (new Data(9999999999) / new Data(9999999999)) + " Ожидалось: 1");
            Console.WriteLine("9999999999/9999999998=" + (new Data(9999999999) / new Data(9999999998)) + " Ожидалось: 1");
            Console.WriteLine("9876543210/1234567890=" + (new Data(9876543210) / new Data(1234567890)) + " Ожидалось: 8");
            Console.WriteLine(Data.MaxValue + "/1=" + (Data.MaxValue / Data.One) + " Ожидалось: " + Data.MaxValue);
            Console.ReadLine();
            #endregion Тест цел. деления
            #region Тест остатка от деления
            Console.Clear();
            Console.WriteLine("Попытка 1%0");
            try { Console.WriteLine(Data.One % new Data()); }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("0%1=" + new Data() % Data.One + " Ожидалось: " + 0 % 1);
            Console.WriteLine(Data.MaxValue + "%1=" + Data.MaxValue % Data.One + " Ожидалось: 0");
            Console.WriteLine((Data.MaxValue - Data.One) + "%" + Data.MaxValue + "=" + (Data.MaxValue - Data.One) + " Ожидалось: " + (Data.MaxValue - Data.One));
            Console.WriteLine("120/11=" + new Data(120) % new Data(11) + " Ожидалось: " + 120 % 11);
            Console.WriteLine("-120/11=" + new Data(-120) % new Data(11) + " Ожидалось: " + (-120) % 11);
            Console.WriteLine("120/(-11)=" + new Data(120) % new Data(-11) + " Ожидалось: " + 120 % (-11));
            Console.WriteLine("-120/(-11)=" + new Data(-120) % new Data(-11) + " Ожидалось: " + (-120) % (-11));
            Console.ReadLine();
            #endregion Тест остатка от деления
            #region Тест деления и приведения
            Console.Clear();
            Console.WriteLine("Тест деления и приведения");
            try { Console.WriteLine("1/0=" + Data.Divide(Data.One, new Data()) + " Ожидалось: "); }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("0/1=" + Data.Divide(new Data(), Data.One));
            Console.WriteLine("9999999999/9999999999=" + Data.Divide(new Data(9999999999), new Data(9999999999)));
            Console.WriteLine("9999999999/9999999998=" + Data.Divide(new Data(9999999999), new Data(9999999998)));
            Console.WriteLine("9876543210/1234567890=" + Data.Divide(new Data(9876543210), new Data(1234567890)));
            Console.WriteLine("12/33=" + Data.Divide(new Data(12), new Data(33)));
            Console.WriteLine("-12/33=" + Data.Divide(new Data(-12), new Data(33)));
            Console.WriteLine("12/(-33)=" + Data.Divide(new Data(12), new Data(-33)));
            Console.WriteLine("-12/(-33)=" + Data.Divide(new Data(-12), new Data(-33)));
            Console.WriteLine("-121/11=" + Data.Divide(new Data(-121), new Data(11)));
            Console.WriteLine("121/(-11)=" + Data.Divide(new Data(121), new Data(-11)));
            Data priv1 = Data.Divide(new Data(9999999999), new Data(9999999998));
            Console.WriteLine("(Data)9999999999/9999999998=" + priv1);
            Data priv2 = Data.Divide(new Data(9876543210), new Data(1234567890));
            Console.WriteLine("(Data)9876543210/1234567890=" + priv2);
            Data priv3 = Data.Divide(new Data(-12), new Data(33));
            Console.WriteLine("(Data)(-12)/33=" + priv3);
            Data priv4 = Data.Divide(new Data(121), new Data(-11));
            Console.WriteLine("(Data) 121/(-11)=" + priv4);
            Data priv5 = Data.Divide(Data.One, new Data(2));
            Console.WriteLine("(Data) 1/2=" + priv5);
            Data priv6 = Data.Divide(new Data(499999), new Data(1000000));
            Console.WriteLine("(Data) 499999/1000000=" + priv6);
            Data priv7 = Data.Divide(new Data("9999999999999999999999999"), Data.One);
            Console.WriteLine("(Data) 9999999999999999999999999/1=" + priv7);
            Data priv8 = Data.Divide(new Data("999999999999999999999999"), Data.One);
            Console.WriteLine("(Data) 999999999999999999999999/1=" + priv8);
            Console.ReadLine();
            #endregion Тест деления и приведения 
            #endregion Основные тесты
            #region Тесты скрытых операций (в классе, но не вызываемые напрямую)
            #region Тест на деление Data/int
            Console.Clear();
            Console.WriteLine("Тесты деление Data/int");
            Console.WriteLine("Попытка 1/0");
            try { Console.WriteLine("1/0=" + Data.One / 0); }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("0/1=" + new Data() / 1 + " Ожидалось: 0");
            Console.WriteLine("0/(-1)=" + (new Data() / -1) + " Ожидалось: 0");
            Console.WriteLine("12/33=" + (new Data(12) / 33) + " Ожидалось: 0");
            Console.WriteLine("-12/33=" + (new Data(-12) / 33) + " Ожидалось: 0");
            Console.WriteLine("12/(-33)=" + (new Data(12) / -33) + " Ожидалось: 0");
            Console.WriteLine("-12/(-33)=" + (new Data(-12) / -33) + " Ожидалось: 0");
            Console.WriteLine("121/11=" + (new Data(121) / 11) + " Ожидалось: 11");
            Console.WriteLine("-121/11=" + (new Data(-121) / 11) + " Ожидалось: -11");
            Console.WriteLine("121/(-11)=" + (new Data(121) / -11) + " Ожидалось: -11");
            Console.WriteLine("-121/(-11)=" + (new Data(-121) / -11) + " Ожидалось: 11");
            Console.WriteLine((Data.Base - 1) + "/" + (Data.Base - 1) + "=" + (new Data((Data.Base - 1).ToString()) / (Data.Base - 1)) + " Ожидалось: 1");
            Console.WriteLine((Data.Base - 2) + "/" + (Data.Base - 1) + "=" + (new Data((Data.Base - 2).ToString()) / (Data.Base - 1)) + "Ожидалось: 1");
            Console.WriteLine((Data.Base - 1) + "/" + (Data.Base - 2) + "=" + (new Data((Data.Base - 1).ToString()) / (Data.Base - 2)) + "Ожидалось: 1");
            Console.WriteLine("Попытка " + int.MaxValue + "/" + int.MaxValue);
            try { Console.WriteLine(int.MaxValue + "/" + int.MaxValue + "=" + (new Data(int.MaxValue.ToString()) / int.MaxValue) + "Ожидалось: 1"); }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.ReadLine();
            #endregion Тест на деление Data/int
            #region Тест на деление long/Data
            Console.Clear();
            Console.WriteLine("Тесты на деление long/Data");
            Console.WriteLine("Попытка 1/0");
            try { Console.WriteLine(1 / new Data()); }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("0/1=" + 0 / Data.One + " Ожидалось: 0");
            Console.WriteLine("987654321/123456789=" + 987654321 / new Data(123456789) + " Ожидалось: 8 с хвостиком");
            Console.WriteLine("-1/2=" + (-1) / new Data(2) + " Ожидалось: -0.5");
            Console.ReadLine();
            #endregion Тест на деление long/Data
            #endregion Тест скрытых операций
            #region Переборные тесты
            #region Тесты полный перебор от -N до N
            long N = 100;
            Console.Clear();
            Console.WriteLine("Тестирование действий с числами не больше " + N + "по модулю");
            Console.ReadLine();
            List<long> first = new List<long>();
            List<long> second = new List<long>();
            List<string> error = new List<string>();
            for (long i = -N + 1; i < N; i++)
            {
                Console.Clear();
                Console.WriteLine(i);
                for (long j = i; j < N; j++)
                {
                    try
                    {
                        Data f = new Data(i.ToString());
                        Data s = new Data(j.ToString());
                        Data res1 = f + s;
                        if (res1 != new Data((i + j).ToString()))
                        {
                            first.Add(i);
                            second.Add(j);
                            error.Add("+: Ожидалось:" + (i + j).ToString() + ", получили:" + res1.ToString());
                        }
                        Data res2 = f - s;
                        if (res2 != new Data((i - j).ToString()))
                        {
                            first.Add(i);
                            second.Add(j);
                            error.Add("-: Ожидалось:" + (i - j).ToString() + ", получили:" + res2.ToString());
                        }
                        Data res3 = f * s;
                        if (res3 != new Data((i * j).ToString()))
                        {
                            first.Add(i);
                            second.Add(j);
                            error.Add("*: Ожидалось:" + (i * j).ToString() + ", получили:" + res3.ToString());
                        }
                        if (j != 0)
                        {
                            Data res4 = f / s;
                            if (res4 != new Data((i / j).ToString()))
                            {
                                first.Add(i);
                                second.Add(j);
                                error.Add("/: Ожидалось:" + (i / j).ToString() + ", получили:" + res4.ToString());
                            }
                            Data res5 = f % s;
                            if (res5 != new Data((i % j).ToString()))
                            {
                                first.Add(i);
                                second.Add(j);
                                error.Add("%: Ожидалось:" + i % j + " Получили:" + res5);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        first.Add(i);
                        second.Add(j);
                        error.Add(e.Message);
                    }
                    try
                    {
                        Data f = new Data(j.ToString());
                        Data s = new Data(i.ToString());
                        Data res1 = f + s;
                        if (res1 != new Data((i + j).ToString()))
                        {
                            first.Add(j);
                            second.Add(i);
                            error.Add("+: Ожидалось:" + (i + j).ToString() + ", получили:" + res1.ToString());
                        }
                        Data res2 = f - s;
                        if (res2 != new Data((j - i).ToString()))
                        {
                            first.Add(j);
                            second.Add(i);
                            error.Add("-: Ожидалось:" + (j - i).ToString() + ", получили:" + res2.ToString());
                        }
                        Data res3 = f * s;
                        if (res3 != new Data((i * j).ToString()))
                        {
                            first.Add(j);
                            second.Add(i);
                            error.Add("*: Ожидалось:" + (i * j).ToString() + ", получили:" + res3.ToString());
                        }
                        if (i != 0)
                        {
                            Data res4 = f / s;
                            if (res4 != new Data((j / i).ToString()))
                            {
                                first.Add(i);
                                second.Add(j);
                                error.Add("/: Ожидалось:" + (j / i).ToString() + ", получили:" + res4.ToString());
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        first.Add(j);
                        second.Add(i);
                        error.Add(e.Message);
                    }

                }
            }
            Console.WriteLine("Количество ошибок: " + first.Count);
            //Console.WriteLine(first[0] + " " + second[0] + " " + error[0]);
            Console.ReadLine();
            #endregion
            #region Рандомные тесты + - * / %
            int NumberOfRepeats = 100000;
            int interval = 1000;
            Console.WriteLine("Рандомные тесты:  " + NumberOfRepeats);
            Console.ReadLine();
            Random rnd = new Random();
            for (int i = 0; i < NumberOfRepeats; i++)
            {
                if (i % interval == 0)
                {
                    Console.Clear();
                    Console.WriteLine(i);
                }
                long a = rnd.Next() * int.MaxValue + rnd.Next();
                long b = rnd.Next() * int.MaxValue + rnd.Next();
                try
                {
                    Data f = new Data(a.ToString());
                    Data s = new Data(b.ToString());
                    Data res1 = f + s;
                    if (res1 != new Data((a + b).ToString()))
                    {
                        first.Add(a);
                        second.Add(b);
                        error.Add("+: Ожидалось:" + (a + b).ToString() + ", получили:" + res1.ToString());
                    }
                    Data res2 = f - s;
                    if (res2 != new Data((a - b).ToString()))
                    {
                        first.Add(a);
                        second.Add(b);
                        error.Add("-: Ожидалось:" + (a - b).ToString() + ", получили:" + res2.ToString());
                    }
                    Data res3 = f * s;
                    if (res3 != new Data((a * b).ToString()))
                    {
                        first.Add(a);
                        second.Add(b);
                        error.Add("*: Ожидалось:" + (a * b).ToString() + ", получили:" + res3.ToString());
                    }
                    Data res4 = f / s;
                    if (res4 != new Data((a / b).ToString()))
                    {
                        first.Add(a);
                        second.Add(b);
                        error.Add("/: Ожидалось:" + (a / b).ToString() + ", получили:" + res4.ToString());
                    }
                    Data res5 = f % s;
                    if (res5 != new Data((a % b).ToString()))
                    {
                        first.Add(a);
                        second.Add(b);
                        error.Add("%: Ожидалось:" + (a % b).ToString() + ", получили:" + res5.ToString());
                    }
                }
                catch (Exception e)
                {
                    first.Add(a);
                    second.Add(b);
                    error.Add(e.Message);
                }
            }
            Console.WriteLine("Количество ошибок:" + first.Count);
            for (int i = 0; i < first.Count; i++)
            {
                Console.WriteLine(first[i] + " " + second[i] + " " + error[i]);
            }
            Console.ReadLine();
            #endregion Рандомные тесты + - * / %
            #region Рандомные тесты на Divide
            int NumberOfTestDivide = 1000000;
            int IntervalForTestDivide = 1000;
            Random r2 = new Random();
            double TopLoss = 0, divRes = 0;
            long div1 = 0, div2 = 0;
            for (int i = 0; i < NumberOfTestDivide; i++)
            {
                if (i % IntervalForTestDivide == 0)
                {
                    Console.Clear();
                    Console.WriteLine(i);
                }
                long l1 = r2.Next() * int.MaxValue + r2.Next();
                long l2 = r2.Next() * int.MaxValue + r2.Next();
                double res = (double)l1 / l2;
                Data dl1 = new Data(l1.ToString());
                Data dl2 = new Data(l2.ToString());
                double resd = Data.Divide(dl1, dl2);
                double Loss = Math.Abs((res - resd) / res);
                if (Loss > TopLoss)
                {
                    TopLoss = Loss;
                    div1 = l1;
                    div2 = l2;
                    divRes = resd;
                }
            }
            Console.WriteLine("Наибольшая потеря: {0} при {1}/{2}", TopLoss, div1, div2);
            Console.WriteLine("Double: " + (double)div1 / div2);
            Console.WriteLine("Data: " + divRes);
            Console.ReadLine();
            #endregion Рандомные тесты на Divide
            #region Рандомные тесты на приведение

            Console.Clear();

            Random rndImplicit = new Random();
            double MaxLoss = 0;
            Data D1 = Data.One, D2 = Data.One;
            int NumberOfTestsImplicit = 100000, IntervalImplicit = 1000;
            for (int i = 0; i < NumberOfTestsImplicit; i++)
            {
                if (i % IntervalImplicit == 0)
                {
                    Console.Clear();
                    Console.WriteLine(i);
                }
                int size = rndImplicit.Next(5) + 1;
                string number = "";
                for (int j = 0; j < size; j++)
                {
                    int temp = rndImplicit.Next(Data.Base);
                    int b = Data.Base / 10;
                    while (temp / b == 0 && b > 1)
                    {
                        number += "0";
                        b /= 10;
                    }
                    number += temp;
                }

                Data DNumber = new Data(number);
                if (DNumber != new Data())
                {
                    double d = Data.Divide(DNumber, Data.One);
                    Data DResNumber = d;
                    double loss = Math.Abs(Data.Divide(Data.Abs(DNumber - DResNumber), DNumber));
                    if (loss > MaxLoss)
                    {
                        MaxLoss = loss;
                        D1 = DNumber;
                        D2 = DResNumber;
                    }
                }
            }
            Console.WriteLine("Наибольшая потеря: " + MaxLoss + " Было:" + D1 + " Стало:" + D2);
            Console.ReadLine();
            #endregion Рандомные тесты на приведение
            #endregion Переборные тесты
            #region Различные другие тесты
            Console.Clear();
            Random r = new Random();
            Data[] ar = new Data[10];
            for (int i = 0; i < 10; i++)
            {
                int x = r.Next();
                ar[i] = new Data(x.ToString());
            }
            Console.WriteLine("До сортировки:");
            foreach (Data d in ar) Console.WriteLine(d);
            Array.Sort(ar);
            Console.WriteLine("После сортировки:");
            foreach (Data d in ar) Console.WriteLine(d);
            Console.ReadLine();
            #endregion Различные другие тесты
        }
    }
}
