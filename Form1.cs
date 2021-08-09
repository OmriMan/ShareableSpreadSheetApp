using Simulator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpreadsheetApp
{
    public partial class Form1 : Form
    {
        ShareableSpreadSheet spreadSheet;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = textBox2.Text;
            //MessageBox.Show(path);

            string[] lines = System.IO.File.ReadAllLines(path);
            int rows = 0;
            int cols = 0;
            // get sizes
            for (int i = 0; i < 2; i++)
            {
                string line = lines[i];
                if (i == 0) { rows = int.Parse(line); }
                if (i == 1) { cols = int.Parse(line); }
            }

            this.spreadSheet = new ShareableSpreadSheet(rows, cols);
            this.spreadSheet.load(path);

            for (int i = 0; i < cols; i++)
            {
                dataGridView1.Columns.Add("col {i}", "");
            }
            for (int i = 0; i < rows; i++)
            {
                dataGridView1.Rows.Add();
            }

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    dataGridView1[i, j].Value = spreadSheet.getCell(j, i);
                    //dataGridView1[i, j].Value = ("cell" + j + i);
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = textBox4.Text;
            string[] data = path.Split(',');
            int row = int.Parse(data[0]);
            int col = int.Parse(data[1]);
            string wantedCell = this.spreadSheet.getCell(row, col);
            if (wantedCell != null)
            {
                MessageBox.Show(wantedCell);
            }

            else
            {
                MessageBox.Show("NOT EXIST");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = textBox7.Text;
            string[] data = path.Split(',');
            int row = int.Parse(data[0]);
            int col = int.Parse(data[1]);
            string value = data[2];

            bool flag = this.spreadSheet.setCell(row,col,value);

            if (flag)
            {
                string toShow = "The additon succsess!\n" + "Row: " + row + ", Coulmn: " + col + ", New value: " + value;
                dataGridView1[row,col].Value = value;
                MessageBox.Show(toShow);               
            }

            else
            {
                MessageBox.Show("Invalid parameters");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
