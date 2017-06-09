using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Functions;
namespace CalcFormApp
{
    class Dialog
    {
        public static void ShowErrorMessage(string error)
        {
            if (error != "")
            {
                MessageBox.Show(error);
                error = "";
            }
        }
    }
}
