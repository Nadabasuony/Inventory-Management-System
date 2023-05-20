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
    public partial class Form2 : Form
    {
        TradingCompanyEntities Ent = new TradingCompanyEntities();
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.FromArgb(34, 140, 184)), new Rectangle(0, 0, Width, 80));
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            foreach (Store st in Ent.Stores)
            {
                comboBox1.Items.Add(st.Store_ID);
                listBox1.Items.Add("\t" + st.Store_ID + "\t" + st.Store_Name);
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
            Store st = Ent.Stores.Find(id);
            textBox1.Text = st.Store_ID.ToString();
            textBox2.Text = st.Store_Name;
            textBox3.Text = st.Store_Address;
            textBox4.Text = st.Store_Manager;
        }

        //ADD BUTTON
        private void button1_Click(object sender, EventArgs e) 
        {
            Store st = new Store();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                Store s = Ent.Stores.Find(int.Parse(textBox1.Text));

                if (s == null)
                {
                    st.Store_ID = int.Parse(textBox1.Text);
                    st.Store_Name = textBox2.Text;
                    st.Store_Address = textBox3.Text;
                    st.Store_Manager = textBox4.Text;
                    Ent.Stores.Add(st);
                    Ent.SaveChanges();
                    comboBox1.Items.Add(textBox1.Text);
                    listBox1.Items.Add("\t" + st.Store_ID + "\t" + st.Store_Name);
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                    MessageBox.Show("Added Successfully.", "Done!");
                }
                else
                {
                    MessageBox.Show("Store already exists.", "Warning!");
                }
            }
            else
            {
                MessageBox.Show("Please fill all the data.", "Warning!");
            }
        }

        //UPDATE BUTTON
        private void button2_Click(object sender, EventArgs e)
        {
            Store st = Ent.Stores.Find(int.Parse(textBox1.Text));
            if (st != null)
            {
                if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    st.Store_Name = textBox2.Text;
                    st.Store_Address = textBox3.Text;
                    st.Store_Manager = textBox4.Text;
                    Ent.SaveChanges();
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                    listBox1.Items.Clear();
                    foreach (Store sto in Ent.Stores)
                    {
                        listBox1.Items.Add("\t" + sto.Store_ID + "\t" + sto.Store_Name);
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
