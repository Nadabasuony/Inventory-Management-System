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
    public partial class Form5 : Form
    {
        TradingCompanyEntities Ent = new TradingCompanyEntities();
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.FromArgb(34, 140, 184)), new Rectangle(0, 0, Width, 80));
        }

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            foreach (Customer cu in Ent.Customers)
            {
                comboBox1.Items.Add(cu.Cust_ID);
                listBox1.Items.Add("\t" + cu.Cust_ID + "\t" + cu.Cust_Name);
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
            Customer cu = Ent.Customers.Find(id);
            textBox1.Text = cu.Cust_ID.ToString();
            textBox2.Text = cu.Cust_Name;
            textBox3.Text = cu.Cust_Mobile.ToString();
            textBox4.Text = cu.Cust_Telephone.ToString();
            textBox5.Text = cu.Cust_Fax.ToString();
            textBox6.Text = cu.Cust_Email;
            textBox7.Text = cu.Cust_Website;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer cu = new Customer();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                Customer s = Ent.Customers.Find(int.Parse(textBox1.Text));

                if (s == null)
                {
                    cu.Cust_ID = int.Parse(textBox1.Text);
                    cu.Cust_Name = textBox2.Text;
                    cu.Cust_Mobile = int.Parse(textBox3.Text);
                    cu.Cust_Telephone = int.Parse(textBox4.Text);
                    cu.Cust_Fax = int.Parse(textBox5.Text);
                    cu.Cust_Email = textBox6.Text;
                    cu.Cust_Website = textBox7.Text;
                    Ent.Customers.Add(cu);
                    Ent.SaveChanges();
                    comboBox1.Items.Add(textBox1.Text);
                    listBox1.Items.Add("\t" + cu.Cust_ID + "\t" + cu.Cust_Name);
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
                    MessageBox.Show("Added Successfully.", "Done!");
                }
                else
                {
                    MessageBox.Show("Customer already exists.", "Warning!");
                }
            }
            else
            {
                MessageBox.Show("Please fill all the data.", "Warning!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer cu = Ent.Customers.Find(int.Parse(textBox1.Text));
            if (cu != null)
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
                {
                    cu.Cust_ID = int.Parse(textBox1.Text);
                    cu.Cust_Name = textBox2.Text;
                    cu.Cust_Mobile = int.Parse(textBox3.Text);
                    cu.Cust_Telephone = int.Parse(textBox4.Text);
                    cu.Cust_Fax = int.Parse(textBox5.Text);
                    cu.Cust_Email = textBox6.Text;
                    cu.Cust_Website = textBox7.Text;
                    Ent.SaveChanges();
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
                    listBox1.Items.Clear();
                    foreach (Customer c in Ent.Customers)
                    {
                        listBox1.Items.Add("\t" + c.Cust_ID + "\t" + c.Cust_Name);
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
