using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAppDereza_laba2_FOR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textMarks.Text = Properties.Settings.Default.str.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = textMarks.Text;
            int[] array;

            try
            {
                array = textMarks.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n.Trim())).ToArray();
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный ввод", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Properties.Settings.Default.str = str;
            Properties.Settings.Default.Save();

            var r = Logic.CountAll(array);
            MessageBox.Show($"Пятёрок: {r.five}, Четвёрок: {r.four}, Троек: {r.three}, Двоек: {r.two}.");
        }
    }
    public struct Result
    {
        public int five;
        public int four;
        public int three;
        public int two;
    }

    public class Logic
    {
        public static Result CountAll(int[] array)
        {
            var r = new Result();
            r.five = Logic.Math5(array);
            r.four = Logic.Math4(array);
            r.three = Logic.Math3(array);
            r.two = Logic.Math2(array);
            return r;
        }
        public static int Math5(int[] array)
        {
            int sum5 = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 5)
                {
                    sum5++;
                }
            }
            return sum5;
        }
        public static int Math4(int[] array)
        {
            int sum4 = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 4)
                {
                    sum4++;
                }
            }
            return sum4;
        }
        public static int Math3(int[] array)
        {
            int sum3 = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 3)
                {
                    sum3++;
                }
            }
            return sum3;
        }
        public static int Math2(int[] array)
        {
            int sum2 = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 2)
                {
                    sum2++;
                }
            }
            return sum2;
        }
    }
}
