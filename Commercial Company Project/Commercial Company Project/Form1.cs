using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Commercial_Company_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button6.Visible = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.FromArgb(34, 140, 184)), new Rectangle(0, 0, Width, 80));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = false;
            button6.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = false;
            button6.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = button2.Enabled = button4.Enabled = button5.Enabled = false;
            button6.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = button2.Enabled = button3.Enabled = button5.Enabled = false;
            button6.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = false;
            button6.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(button1.Enabled == true)
            {
                Form2 form2 = new Form2();
                this.Hide();
                form2.ShowDialog();
                this.Close();
            }
            else if (button2.Enabled == true)
            {
                //Form3 form3 = new Form3();
                this.Hide();
                //form3.ShowDialog();
                this.Close();
            }
            else if (button3.Enabled == true)
            {
                //Form4 form4 = new Form4();
                this.Hide();
                //form4.ShowDialog();
                this.Close();
            }
            else if (button4.Enabled == true)
            {
                //Form5 form5 = new Form5();
                this.Hide();
                //form5.ShowDialog();
                this.Close();
            }
            else
            {
                //Form6 form6 = new Form6();
                this.Hide();
                //form6.ShowDialog();
                this.Close();
            }
        }
    }
}
