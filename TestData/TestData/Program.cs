﻿using System;
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
            #region Тест конструтора+Copy
            Console.WriteLine("Тест конструтора+Copy");
            Data d1 = new Data();
            Console.WriteLine(d1);
            Data d2 = new Data("1");
            Console.WriteLine(d2);
            Data d3 = new Data("-1");
            Console.WriteLine(d3);
            Console.WriteLine("Создание по строке --1");
            try {Data d4 = new Data("--1");}
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Создание по пустой строке");
            try {Data d5 = new Data("");}
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Создание по строке ABC");
            try { Data d6 = new Data("ABC");}
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Data d7 = new Data("9999999999999999999999999");
            Console.WriteLine(d7);
            Console.WriteLine("Создание по строке 99999999999999999999999999 (26 девяток)");
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
            Console.WriteLine("Тест сравнений");
            Console.WriteLine("0 == 0" + (new Data() == new Data()) + " Ожидалось: True");
            Console.WriteLine("0 > 0" + (new Data() > new Data()) + " Ожидалось: False");
            Console.WriteLine("0 < 0" + (new Data() < new Data()) + " Ожидалось: False");
            Console.WriteLine("-1 < 1" + (new Data("-1") < new Data("1")) + " Ожидалось: True");
            Console.WriteLine("-1 == 1"+(new Data("-1") == new Data("1")) + " Ожидалось: False");
            Console.WriteLine("-1 > 1"+(new Data("-1") > new Data("1")) + " Ожидалось: False");
            Console.WriteLine("1 < -1"+(new Data("1") < new Data("-1")) + " Ожидалось: False");
            Console.WriteLine("1 == -1"+(new Data("1") == new Data("-1")) + " Ожидалось: False");
            Console.WriteLine("1 > -1" + (new Data("1") > new Data("-1")) + " Ожидалось: True ");
            Console.WriteLine("100000 > 1" + (new Data("100000") > new Data("1")) + " Ожидалось: True");
            Console.WriteLine("100000 == 1" + (new Data("100000") == new Data("1")) + " Ожидалось: False");
            Console.WriteLine("100000 < 1" + (new Data("100000") < new Data("1")) + " Ожидалось: False");
            Console.WriteLine("1>100000"+(new Data("1") > new Data("100000")) + " Ожидалось: False");
            Console.WriteLine("1==100000" + (new Data("1") == new Data("100000")) + " Ожидалось: False");
            Console.WriteLine("1<100000" + (new Data("1") < new Data("100000")) + " Ожидалось: True");
            Console.WriteLine("9999999999999999999999999 == 9999999999999999999999999" +
                ( new Data("9999999999999999999999999") == new Data("9999999999999999999999999")) + " Ожидалось: True");
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
            Data inc = new Data("-1");
            Console.WriteLine("++(-1)=" + (++inc) + " Ожидалось:  0");
            Console.WriteLine("++0="+ (++inc) + " Ожидалось:  1");
            Console.WriteLine("++1=" + (++inc) + " Ожидалось:  2");
            inc = new Data("9999");
            Console.WriteLine("++9999=" + (++inc) + " Ожидалось:  10000");
            Console.WriteLine("0+0="+(new Data() + new Data()) + " Ожидалось:  0");
            Console.WriteLine("0+10="+(new Data() + new Data("10")) + " Ожидалось:  10");
            Console.WriteLine("10+0="+(new Data("10") + new Data()) + " Ожидалось:  10");
            Console.WriteLine("1000000000+1=" + (new Data("1000000000") + new Data("1")) + " Ожидалось: 1000000001");
            Console.WriteLine("9+1="+(new Data("9") + new Data("1")) + " Ожидалось:  10");
            Console.WriteLine("109999999999+1=" + (new Data("109999999999") + new Data("1")) + " Ожидалось: 110000000000");
            Console.WriteLine("-10+(-100)="+(new Data("-10") + new Data("-100")) + " Ожидалось: -110");
            Console.WriteLine("Попытка подсчитать 9999999999999999999999999 + 1 (25 девяток + 1)");
            try { Data s = Data.MaxValue + Data.One; }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("999999999999999999999999+1=" + (new Data("999999999999999999999999") + Data.One) + " Ожидалось: 1000000000000000000000000");
            Console.WriteLine("10+(-10)="+(new Data("10") + new Data("-10")) + " Ожидалось: 0");
            Console.WriteLine("99+(-9)=" + (new Data("99") + new Data("-9")) + " Ожидалось: 90");
            Console.WriteLine("9+(-99)=" + (new Data("9") + new Data("-99")) + " Ожидалось: -90");
            Console.WriteLine("-9+99=" + (new Data("-9") + new Data("99")) + " Ожидалось: 90");
            Console.WriteLine("-99+9=" + (new Data("-99") + new Data("9")) + " Ожидалось: -90");
            Console.WriteLine("0-0=" + (new Data() - new Data()) + " Ожидалось: 0");
            Console.WriteLine("0-10=" + (new Data() - new Data("10")) + " Ожидалось: -10");
            Console.WriteLine("10-0=" + (new Data("10") - new Data("0")) + " Ожидалось: 10");
            Console.WriteLine("100000000-1=" + (new Data("100000000") - new Data("1")) + " Ожидалось: 99999999");
            Console.WriteLine("1-100000000=" + (new Data("1") - new Data("100000000")) + " Ожидалось: -99999999");
            Console.WriteLine("-10-(-100)=" + (new Data("-10") - new Data("-100")) + " Ожидалось: 90");
            Console.WriteLine("10-(-10)=" + (new Data("10") - new Data("-10")) + " Ожидалось: 20");
            Console.WriteLine("-10-10=" + (new Data("-10") - new Data("10")) + " Ожидалось: -20");

            Console.ReadLine();
            #endregion Тест сложения и вычитания
            #region Тест умножения 
            Console.Clear();
            Console.WriteLine("Тест умножения");
            Console.WriteLine("0*0=" + (new Data() * new Data()) + " Ожидалось: 0");
            Console.WriteLine("1000000*0=" + (new Data("1000000") * new Data()) + " Ожидалось: 0");
            Console.WriteLine("0*1000000=" + (new Data() * new Data("1000000")) + " Ожидалось: 0");
            Console.WriteLine("1000000*1=" + (new Data("1000000") * new Data("1")) + " Ожидалось: 1000000");
            Console.WriteLine("1*1000000=" + (new Data("1") * new Data("1000000")) + " Ожидалось: 1000000");
            Console.WriteLine("1000*1000=" + (new Data("1000") * new Data("1000")) + " Ожидалось: 1000000");
            Console.WriteLine("10000001*10000001=" + (new Data("10000001") * new Data("10000001")) + " Ожидалось: 100000020000001");
            Console.WriteLine("-1*1000=" + (new Data("-1") * new Data("1000")) + " Ожидалось: -1000");
            Console.WriteLine("1000*(-1)=" + (new Data("1000") * new Data("-1")) + " Ожидалось: -1000");
            Console.WriteLine("1234567890*987654321=" + (new Data("1234567890") * new Data("987654321")) + " "
                + ((new Data("1234567890") * new Data("987654321")) == new Data("1219326311126352690")) + " Ожидалось: 1219326311126352690");
            Console.WriteLine("-1234567890*987654321=" + (new Data("-1234567890") * new Data("987654321")) + " "
               + ((new Data("-1234567890") * new Data("987654321")) == new Data("-1219326311126352690")) + " Ожидалось: -1219326311126352690");
            Console.WriteLine("-1234567890*(-987654321)=" + (new Data("-1234567890") * new Data("-987654321")) + " "
               + ((new Data("-1234567890") * new Data("-987654321")) == new Data("1219326311126352690")) + " Ожидалось: 1219326311126352690");
            Console.WriteLine("Попытка подсчитать 9999999999999999999999999*10 (25 девяток * 10)");
            try { Console.WriteLine("9999999999999999999999999*10=" + (Data.MaxValue * new Data("10"))); }
            catch(Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("Попытка подсчитать 99999999999999999999*1000000 (20 девяток * 1000000)");
            try { Console.WriteLine("99999999999999999999*1000000=" + 
                (new Data("99999999999999999999") * new Data("1000000"))); }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("1111111111111111111111111*9=" + (new Data("1111111111111111111111111") * new Data("9")) + " Ожидалось: 9999999999999999999999999");
            Console.WriteLine("Попытка подсчитать 1111111111111111111111111*10 (25 едениц * 10");
            try
            {
                Console.WriteLine("1111111111111111111111111*10=" + 
                    (new Data("1111111111111111111111111") * new Data("10")));
            }
            catch(Exception e) { Console.WriteLine(e.Message); }
            Console.ReadLine();
            #endregion Тест умножения 
            #region Тест цел. деления
            Console.Clear();
            Console.WriteLine("Тест цел. деления");
            try
            {
                Console.WriteLine("1/0=" + (new Data("1") / new Data()));
            } 
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("0/1=" + (new Data() / new Data("1")) + " Ожидалось: 0");
            Console.WriteLine("0/(-1)=" + (new Data() / new Data("-1")) + " Ожидалось: 0");
            Console.WriteLine("12/33=" + (new Data("12") / new Data("33")) + " Ожидалось: 0");
            Console.WriteLine("-12/33=" + (new Data("-12") / new Data("33")) + " Ожидалось: 0");
            Console.WriteLine("12/(-33)=" + (new Data("12") / new Data("-33")) + " Ожидалось: 0");
            Console.WriteLine("-12/(-33)=" + (new Data("-12") / new Data("-33")) + " Ожидалось: 0");
            Console.WriteLine("121/11=" + (new Data("121") / new Data("11")) + " Ожидалось: 11");
            Console.WriteLine("-121/11=" + (new Data("-121") / new Data("11")) + " Ожидалось: -11");
            Console.WriteLine("121/(-11)=" + (new Data("121") / new Data("-11")) + " Ожидалось: -11");
            Console.WriteLine("-121/(-11)=" + (new Data("-121") / new Data("-11")) + " Ожидалось: 11");
            Console.WriteLine("9999999999/9999999999=" + (new Data("9999999999") / new Data("9999999999")) + " Ожидалось: 1");
            Console.WriteLine("9999999999/9999999998=" + (new Data("9999999999") / new Data("9999999998")) + " Ожидалось: 1");
            Console.WriteLine("9876543210/1234567890=" + (new Data("9876543210") / new Data("1234567890")) + " Ожидалось: 8");
            Console.ReadLine();
            #endregion Тест цел. деления
            #region Тест деления и приведения
            Console.Clear();
            Console.WriteLine("Тест деления и приведения");
            try { Console.WriteLine("1/0=" + Data.Divide(new Data("1"), new Data()) + " Ожидалось: "); }
            catch(Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("0/1=" + Data.Divide(new Data(), new Data("1")));
            Console.WriteLine("9999999999/9999999999=" + Data.Divide(new Data("9999999999"), new Data("9999999999")));
            Console.WriteLine("9999999999/9999999998=" + Data.Divide(new Data("9999999999"), new Data("9999999998")));
            Console.WriteLine("9876543210/1234567890=" + Data.Divide(new Data("9876543210"), new Data("1234567890")));
            Console.WriteLine("12/33=" + Data.Divide(new Data("12"), new Data("33")));
            Console.WriteLine("-12/33=" + Data.Divide(new Data("-12"), new Data("33")));
            Console.WriteLine("12/(-33)=" + Data.Divide(new Data("12"),new Data("-33")));
            Console.WriteLine("-12/(-33)=" + Data.Divide(new Data("-12"), new Data("-33")));
            Console.WriteLine("-121/11=" + Data.Divide(new Data("-121"), new Data("11")));
            Console.WriteLine("121/(-11)=" + Data.Divide(new Data("121"), new Data("-11")));
            Data priv1 = Data.Divide(new Data("9999999999"), new Data("9999999998"));
            Console.WriteLine("(Data)9999999999/9999999998=" + priv1);
            Data priv2 = Data.Divide(new Data("9876543210"), new Data("1234567890"));
            Console.WriteLine("(Data)9876543210/1234567890=" + priv2);
            Data priv3 = Data.Divide(new Data("-12"), new Data("33"));
            Console.WriteLine("(Data)(-12)/33=" + priv3);
            Data priv4 = Data.Divide(new Data("121"), new Data("-11"));
            Console.WriteLine("(Data) 121/(-11)=" + priv4);
            Data priv5 = Data.Divide(new Data("1"), new Data("2"));
            Console.WriteLine("(Data) 1/2=" + priv5);
            Data priv6 = Data.Divide(new Data("499999"), new Data("1000000"));
            Console.WriteLine("(Data) 499999/1000000=" + priv6);
            Data priv7 = Data.Divide(new Data("9999999999999999999999999"), new Data("1"));
            Console.WriteLine("(Data) 9999999999999999999999999/1=" + priv7);
            Data priv8 = Data.Divide(new Data("999999999999999999999999"), new Data("1"));
            Console.WriteLine("(Data) 999999999999999999999999/1=" + priv8);
            Console.ReadLine();
            #endregion Тест деления и приведения 
            #region Авто-тесты
            long N = 100;
            Console.WriteLine("Тестирование действий с числами не больше " + N + "по модулю");
            Console.ReadLine();
            List<long> first = new List<long>();
            List<long> second = new List<long>();
            List<string> error = new List<string>();
            for (long i = -N+1; i < N; i++)
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
                        if (res1!=new Data((i + j).ToString()))
                        {
                            first.Add(i);
                            second.Add(j);
                            error.Add("+: Ожидалось:" + (i + j).ToString() + ", получили:" + res1.ToString());
                        }
                        Data res2 = f - s;
                        if (res2!=new Data((i - j).ToString())) {
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
                        if (j != 0) { 
                            Data res4 = f / s;
                            if (res4 != new Data((i / j).ToString()))
                            {
                                first.Add(i);
                                second.Add(j);
                                error.Add("/: Ожидалось:" + (i / j).ToString() + ", получили:" + res4.ToString());
                            }
                        }
                    }catch(Exception e)
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
                        if (res2 != new Data((j-i).ToString()))
                        {
                            first.Add(j);
                            second.Add(i);
                            error.Add("-: Ожидалось:" + (j-i).ToString() + ", получили:" + res2.ToString());
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
                            if (res4 != new Data((j/i).ToString()))
                            {
                                first.Add(i);
                                second.Add(j);
                                error.Add("/: Ожидалось:" + (j/i).ToString() + ", получили:" + res4.ToString());
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
            Console.ReadLine();
            int NumberOfRepeats = 1000000;
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
                long a = rnd.Next();
                long b = rnd.Next();
                try
                {
                    Data f = new Data(a.ToString());
                    Data s = new Data(b.ToString());
                    Data res1 = f + s;
                    if (res1 != new Data((a+b).ToString()))
                    {
                        first.Add(a);
                        second.Add(b);
                        error.Add("+: Ожидалось:" + (a+b).ToString() + ", получили:" + res1.ToString());
                    }
                    Data res2 = f - s;
                    if (res2 != new Data((a-b).ToString()))
                    {
                        first.Add(a);
                        second.Add(b);
                        error.Add("-: Ожидалось:" + (a-b).ToString() + ", получили:" + res2.ToString());
                    }
                    Data res3 = f * s;
                    if (res3 != new Data((a*b).ToString()))
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
                }
                catch (Exception e)
                {
                    first.Add(a);
                    second.Add(b);
                    error.Add(e.Message);
                }
            }
            Console.WriteLine("Количество ошибок:"+first.Count);
            for (int i = 0; i < first.Count; i++)
            {
                Console.WriteLine(first[i] + " " + second[i] + " " + error[i]);
            }
            Console.ReadLine();
            #endregion Авто-тесты
        }
    }
}
