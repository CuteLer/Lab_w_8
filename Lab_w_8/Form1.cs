using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_w_8
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        int[,] array = new int[10, 10];
        public void input(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rnd.Next(0, 150);
                }
            }
        }
        public void print(int[,] array, DataGridView data)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    data.Rows[i].Cells[j].Value = array[i, j].ToString();
                }
            }
        }

        public void index(int[,] array)
        {
            int max = array[0, 0];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 1; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > max)
                        max = array[i, j];
                }
            }
            label4.Text = "Максимальный элемент " + max.ToString();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 1; j < array.GetLength(1); j++)
                    if (array[i, j] == max)
                    {
                        result(array, i, j);
                    }
            }
        }

        public void result(int[,] array, int i_m, int j_m)
        {

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i == i_m || j == j_m)
                    {
                        array[i, j] = 0;
                    }
                }
            }
            print(array, dataGridView2);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            input(array);
            dataGridView1.RowCount = array.GetLength(0);
            dataGridView1.ColumnCount = array.GetLength(1);

            print(array, dataGridView1);
            dataGridView1.AutoResizeColumns();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            dataGridView2.RowCount = array.GetLength(0);
            dataGridView2.ColumnCount = array.GetLength(1);
            index(array);
            dataGridView2.AutoResizeColumns();

        }

    }
}
