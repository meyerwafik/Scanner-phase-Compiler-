using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Compiler
{

    public partial class Form1 : Form
    {
        Class1 c = new Class1();
        private System.Windows.Forms.Button enter;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {  Form2 f = new Form2();
            f.Show();
            this.Hide();
           
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.ShowDialog();
            textBox1.Text = f.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader r = new StreamReader(textBox1.Text);
            richTextBox1.Text = r.ReadToEnd();
            r.Close();
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();

            c.Compile(richTextBox1.Text);
            Tokenrecord[] z = c.tokenrecords.ToArray();

            for (int i = 0; i < c.tokenindex; i++)
            {

                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = z[i].lexem.ToString();
                dataGridView1.Rows[n].Cells[1].Value = z[i].t.ToString();
                dataGridView1.Rows[n].Cells[2].Value = z[i].lineoflexem.ToString();
               

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();

        }
    }
}
