using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DP_Project
{
    public partial class Form4 : Form
    {
        TradingCompanyEntities Ent = new TradingCompanyEntities();
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.FromArgb(34, 140, 184)), new Rectangle(0, 0, Width, 80));
        }

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            foreach (Supplier su in Ent.Suppliers)
            {
                comboBox1.Items.Add(su.Supp_ID);
                listBox1.Items.Add("\t" + su.Supp_ID + "\t" + su.Supp_Name);
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
            int id = int.Parse(comboBox1.Text);
            Supplier su = Ent.Suppliers.Find(id);
            textBox1.Text = su.Supp_ID.ToString();
            textBox2.Text = su.Supp_Name;
            textBox3.Text = su.Supp_Mobile.ToString();
            textBox4.Text = su.Supp_Telephone.ToString();
            textBox5.Text = su.Supp_Fax.ToString();
            textBox6.Text = su.Supp_Email;
            textBox7.Text = su.Supp_Website;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Supplier su = new Supplier();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                Supplier s = Ent.Suppliers.Find(int.Parse(textBox1.Text));

                if (s == null)
                {
                    su.Supp_ID = int.Parse(textBox1.Text);
                    su.Supp_Name = textBox2.Text;
                    su.Supp_Mobile = int.Parse(textBox3.Text);
                    su.Supp_Telephone = int.Parse(textBox4.Text);
                    su.Supp_Fax = int.Parse(textBox5.Text);
                    su.Supp_Email = textBox6.Text;
                    su.Supp_Website = textBox7.Text;
                    Ent.Suppliers.Add(su);
                    Ent.SaveChanges();
                    comboBox1.Items.Add(textBox1.Text);
                    listBox1.Items.Add("\t" + su.Supp_ID + "\t" + su.Supp_Name);
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
                    MessageBox.Show("Added Successfully.", "Done!");
                }
                else
                {
                    MessageBox.Show("Supplier already exists.", "Warning!");
                }
            }
            else
            {
                MessageBox.Show("Please fill all the data.", "Warning!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Supplier su = Ent.Suppliers.Find(int.Parse(textBox1.Text));
            if (su != null)
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
                {
                    su.Supp_ID = int.Parse(textBox1.Text);
                    su.Supp_Name = textBox2.Text;
                    su.Supp_Mobile = int.Parse(textBox3.Text);
                    su.Supp_Telephone = int.Parse(textBox4.Text);
                    su.Supp_Fax = int.Parse(textBox5.Text);
                    su.Supp_Email = textBox6.Text;
                    su.Supp_Website = textBox7.Text;
                    Ent.SaveChanges();
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
                    listBox1.Items.Clear();
                    foreach (Supplier s in Ent.Suppliers)
                    {
                        listBox1.Items.Add("\t" + s.Supp_ID + "\t" + s.Supp_Name);
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
