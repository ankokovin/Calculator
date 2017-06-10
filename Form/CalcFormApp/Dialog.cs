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
        //Проверка наличия ошибки. При наличии - вывод
        public static void ShowErrorMessage(string error)
        {
            if (error != "")
            {
                MessageBox.Show(error);
                error = "";
            }
        }

        //Проверка наличия последнего действия. При нажатии новой операции выполняет последнюю
        public static bool OperatorCheck(string lastOperand, ref Data operatorMemory, string num, out string error)
        {
            error = "";
            if (lastOperand != "")
            {
                if (lastOperand == "+")
                    operatorMemory = Calculator.Sum(operatorMemory, new Data(num), out error);
                if (lastOperand == "-")
                    operatorMemory = Calculator.Dif(operatorMemory, new Data(num), out error);
                if (lastOperand == "*")
                    operatorMemory = Calculator.Multiply(operatorMemory, new Data(num), out error);
                if (lastOperand == "%")
                    operatorMemory = Calculator.Mod(operatorMemory, new Data(num), out error);
                if (lastOperand == "Div")
                    operatorMemory = Calculator.IntDivide(operatorMemory, new Data(num), out error);
                return true;
            }
            return false;
        }
    }
}   

