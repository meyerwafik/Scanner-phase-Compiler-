using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compiler
{
    

    public partial class Form2 : Form
    {

        Class1 c1 = new Class1();
        public Form2()
        {
            InitializeComponent();
            label1.Text="write your code here";
            MaximizeBox = false;
            

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();

            c1.Compile(richTextBox1.Text);
            Tokenrecord[] z = c1.tokenrecords.ToArray();

            for (int i = 0; i < c1.tokenindex; i++)
            {
               
              int n= dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = z[i].lexem.ToString();
                dataGridView1.Rows[n].Cells[1].Value = z[i].t.ToString();
                dataGridView1.Rows[n].Cells[2].Value = z[i].lineoflexem.ToString();
             

            }
         
            
           


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {  
            

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 fm33 = new Form3();
            fm33.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 fm1 = new Form1();
            fm1.Show();
            this.Hide();
        }
    }
}
