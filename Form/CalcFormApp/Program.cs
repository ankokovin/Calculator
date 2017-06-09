using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Functions;

namespace CalcFormApp
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// Зафиксировать
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
    }
}
