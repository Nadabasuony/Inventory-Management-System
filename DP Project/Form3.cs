using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DP_Project
{
    public partial class Form3 : Form
    {
        TradingCompanyEntities Ent = new TradingCompanyEntities();
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.FromArgb(34, 140, 184)), new Rectangle(0, 0, Width, 80));
        }

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            foreach (Item it in Ent.Items)
            {
                comboBox1.Items.Add(it.Item_Code);
                listBox1.Items.Add("\t" + it.Item_Code + "\t" + it.Item_Name);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int code = int.Parse(comboBox1.Text);
            Item it = Ent.Items.Find(code);
            textBox1.Text = it.Item_Code.ToString();
            textBox2.Text = it.Item_Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Item it = new Item();
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Item i = Ent.Items.Find(int.Parse(textBox1.Text));

                if (i == null)
                {
                    it.Item_Code = int.Parse(textBox1.Text);
                    it.Item_Name = textBox2.Text;
                    Ent.Items.Add(it);
                    Ent.SaveChanges();
                    comboBox1.Items.Add(textBox1.Text);
                    listBox1.Items.Add("\t" + it.Item_Code + "\t" + it.Item_Name);
                    textBox1.Text = textBox2.Text = "";
                    MessageBox.Show("Added Successfully.", "Done!");
                }
                else
                {
                    MessageBox.Show("Item already exists.", "Warning!");
                }
            }
            else
            {
                MessageBox.Show("Please fill all the data.", "Warning!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Item it = Ent.Items.Find(int.Parse(textBox1.Text));
            if (it != null)
            {
                if (textBox2.Text != "")
                {
                    it.Item_Name = textBox2.Text;
                    Ent.SaveChanges();
                    textBox1.Text = textBox2.Text = "";
                    listBox1.Items.Clear();
                    foreach (Item item in Ent.Items)
                    {
                        listBox1.Items.Add("\t" + item.Item_Code + "\t" + item.Item_Name);
                    }
                    MessageBox.Show("Updated Successfully.", "Done!");
                }
                else
                {
                    MessageBox.Show("Please fill all the data.", "Warning!");
                }
            }
            else
            {
                MessageBox.Show("ID is not available.", "Warning!");
            }
        }        
    }
}

