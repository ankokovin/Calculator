using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CalcFormApp
{
    public partial class Menu : Form
    {
        #region Basic Setup
        public Menu()
        {
            InitializeComponent();
        }
        private void MenuForm_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Functions
        private void EqualsSomething_Click(object sender, EventArgs e)
        {

        }
        private void Plus_Click(object sender, EventArgs e)
        {

        }
        private void Clear_Click(object sender, EventArgs e)
        {

        }
        private void Multiply_Click(object sender, EventArgs e)
        {

        }
        private void DivideInt_Click(object sender, EventArgs e)
        {

        }
        private void Minus_Click(object sender, EventArgs e)
        {

        }
        private void Previous_Click(object sender, EventArgs e)
        {

        }
        private void Rest_Click(object sender, EventArgs e)
        {

        }
        private void DivideFloat_Click(object sender, EventArgs e)
        {

        }
        private void PlusMinus_Click(object sender, EventArgs e)
        {
            if (outputInfo.Text.Length != 0)
            {
                if (outputInfo.Text[0] == '-')
                    outputInfo.Text = outputInfo.Text.Remove(0, 1);
                else
                {
                    char[] arr = outputInfo.Text.ToCharArray();
                    outputInfo.Text = "-";

                    for (int i = 0; i < arr.Length; i++)
                        outputInfo.Text = outputInfo.Text + arr[i];
                }
            }
        }
        #endregion

        #region Additional Features
        #region Hidden Info
        private void PlusMinus_MouseHover(object sender, EventArgs e)
        {
            ToolTip info = new ToolTip();
            info.SetToolTip(PlusMinus, "Поменять знак числа");
        }
        private void DivideInt_MouseHover(object sender, EventArgs e)
        {
            ToolTip info = new ToolTip();
            info.SetToolTip(DivideInt, "Целочисленное деление");
        }
        private void Clear_MouseHover(object sender, EventArgs e)
        {
            ToolTip info = new ToolTip();
            info.SetToolTip(Clear, "Сброс результата");
        }
        private void Rest_MouseHover(object sender, EventArgs e)
        {
            ToolTip info = new ToolTip();
            info.SetToolTip(Rest, "Остаток от деления");
        }
        private void Multiply_MouseHover(object sender, EventArgs e)
        {
            ToolTip info = new ToolTip();
            info.SetToolTip(Multiply, "Умножить");
        }
        private void Previous_MouseHover(object sender, EventArgs e)
        {
            ToolTip info = new ToolTip();
            info.SetToolTip(Previous, "Предыдущее действие");
        }
        private void DivideFloat_MouseHover(object sender, EventArgs e)
        {
            ToolTip info = new ToolTip();
            info.SetToolTip(DivideFloat, "Деление с дробной частью");
        }
        #endregion
        #endregion

        #region Input
        #region ButtonInput
        private void Add0_Click(object sender, EventArgs e)
        {
            outputInfo.Text += Add0.Text;
        }
        private void Add1_Click(object sender, EventArgs e)
        {
            outputInfo.Text += Add1.Text;
        }
        private void Add2_Click(object sender, EventArgs e)
        {
            outputInfo.Text += Add2.Text;
        }
        private void Add3_Click(object sender, EventArgs e)
        {
            outputInfo.Text += Add3.Text;
        }
        private void Add4_Click(object sender, EventArgs e)
        {
            outputInfo.Text += Add4.Text;
        }
        private void Add5_Click(object sender, EventArgs e)
        {
            outputInfo.Text += Add5.Text;
        }
        private void Add6_Click(object sender, EventArgs e)
        {
            outputInfo.Text += Add6.Text;
        }
        private void Add7_Click(object sender, EventArgs e)
        {
            outputInfo.Text += Add7.Text;
        }
        private void Add8_Click(object sender, EventArgs e)
        {
            outputInfo.Text += Add8.Text;
        }
        private void Add9_Click(object sender, EventArgs e)
        {
            outputInfo.Text += Add9.Text;
        }
        #endregion
        #region KeyInput
        private void outputInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-')
            {
                e.Handled = true;
                PlusMinus_Click(sender, e);
            }
            else
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                e.Handled = false;
            else
                e.Handled = true;

        }
        private void outputInfo_TextChanged(object sender, EventArgs e)
        {
            if (outputInfo.Text.Length != 0)
            {
                
                if (outputInfo.Text.Length > 26 && outputInfo.Text[0] == '-')
                    outputInfo.Text = outputInfo.Text.Remove(26, 1);
                else
                    if (outputInfo.Text.Length > 25 && outputInfo.Text[0] != '-')
                    outputInfo.Text = outputInfo.Text.Remove(25, 1);
            }
        }

        #endregion
        #endregion
    }
}
