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
    
    public partial class Form2 : Form
    {
        Trading_Company_Entities Ent = new Trading_Company_Entities();
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.FromArgb(34, 140, 184)), new Rectangle(0, 0, Width, 80));
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            foreach (Store st in Ent.Stores)
            {
                comboBox1.Items.Add(st);
            }
        }
    }
}
