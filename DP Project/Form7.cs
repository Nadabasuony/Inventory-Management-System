using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DP_Project
{
    public partial class Form7 : Form
    {
        TradingCompanyEntities Ent = new TradingCompanyEntities();

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.FromArgb(34, 140, 184)), new Rectangle(0, 0, Width, 80));
        }

        public Form7()
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

        private void Form7_Load(object sender, EventArgs e)
        {

            foreach (Transfer_Item ti in Ent.Transfer_Item)
            {
                comboBox0.Items.Add(ti.Trans_ID);
            }

            foreach (Store st in Ent.Stores)
            {
                comboBox1.Items.Add(st.Store_ID);
            }

            foreach (Store st in Ent.Stores)
            {
                comboBox2.Items.Add(st.Store_ID);
            }

            foreach (Supplier su in Ent.Suppliers)
            {
                comboBox3.Items.Add(su.Supp_ID);
            }

            foreach (Item it in Ent.Items)
            {
                comboBox4.Items.Add(it.Item_Code);
            }
        }

        private void comboBox0_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id1 = int.Parse(comboBox0.SelectedItem.ToString());
            Transfer_Item ti = Ent.Transfer_Item.Find(id1);
            comboBox1.SelectedItem = ti.From_ID;
            comboBox2.SelectedItem = ti.To_ID;
            comboBox3.SelectedItem = ti.Supp_ID;
            comboBox4.SelectedItem = ti.Item_Code;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ids = int.Parse(comboBox1.SelectedItem.ToString());
            Store st = Ent.Stores.Find(ids);
            textBox1.Text = st.Store_Name;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ids = int.Parse(comboBox2.SelectedItem.ToString());
            Store st = Ent.Stores.Find(ids);
            textBox2.Text = st.Store_Name;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ids = int.Parse(comboBox3.SelectedItem.ToString());
            Supplier su = Ent.Suppliers.Find(ids);
            textBox3.Text = su.Supp_Name;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ids1 = int.Parse(comboBox1.SelectedItem.ToString());
            Store st = Ent.Stores.Find(ids1);
            int idss1 = st.Store_ID;

            int ids = int.Parse(comboBox4.SelectedItem.ToString());
            Item it = Ent.Items.Find(ids);
            int idss = it.Item_Code;
            textBox4.Text = it.Item_Name;
 
            var si = (from s in Ent.Store_Item
                      where s.Item_Code == idss && s.Store_ID == idss1
                      select s.Item_Total).FirstOrDefault();
            textBox5.Text = si.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Transfer_Item ti = new Transfer_Item();
            Store_Item si = new Store_Item();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                if (textBox5.Text != "" || int.Parse(textBox5.Text) == 0)
                {
                    //TRANSFER_ITEM TABLE
                    ti.From_ID = int.Parse(comboBox1.SelectedItem.ToString());
                    ti.To_ID = int.Parse(comboBox2.SelectedItem.ToString());
                    ti.Supp_ID = int.Parse(comboBox3.SelectedItem.ToString());
                    ti.Item_Code = int.Parse(comboBox4.SelectedItem.ToString());
                    ti.Item_Total = int.Parse(textBox6.Text);
                    ti.Production_Date = dateTimePicker1.Value;
                    ti.Expiration_Date = dateTimePicker2.Value;
                    Ent.Transfer_Item.Add(ti);

                    //STORE_ITEM TABLE
                    var x = (from old in Ent.Store_Item
                             where old.Store_ID == ti.From_ID && old.Item_Code == ti.Item_Code
                             select old.Item_Total).FirstOrDefault();
                    x = int.Parse(textBox5.Text) - int.Parse(textBox6.Text);

                    var y = (from neww in Ent.Store_Item
                             where neww.Store_ID == ti.To_ID && neww.Item_Code == ti.Item_Code
                             select neww.Item_Total).FirstOrDefault();
                    if (y != null) 
                    {
                        y = int.Parse(textBox5.Text) + int.Parse(textBox6.Text);
                    }
                    else
                    {
                        si.Store_ID = int.Parse(ti.To_ID.ToString());
                        si.Item_Code = int.Parse(ti.Item_Code.ToString());
                        si.Item_Total = int.Parse(textBox6.Text);
                        si.Production_Date = dateTimePicker1.Value;
                        si.Expiration_Date = dateTimePicker2.Value;
                        Ent.Store_Item.Add(si);
                    }
                    Ent.SaveChanges();
                    comboBox0.Items.Clear();
                    foreach (Transfer_Item tii in Ent.Transfer_Item)
                    {
                        comboBox0.Items.Add(tii.Trans_ID);
                    }
                    MessageBox.Show("Added Successfully.", "Done!");
                }
                else
                {
                    MessageBox.Show("There is no item to be exported.", "Warning!");
                }
            }
            else
            {
                MessageBox.Show("Please fill all the data.", "Warning!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Transfer_Item ti = Ent.Transfer_Item.Find(int.Parse(comboBox0.SelectedItem.ToString()));
            Store_Item si = new Store_Item();
            if(ti != null)
            {
                if (textBox5.Text != "" || int.Parse(textBox5.Text) == 0)
                {
                    //TRANSFER_ITEM TABLE
                    ti.From_ID = int.Parse(comboBox1.SelectedItem.ToString());
                    ti.To_ID = int.Parse(comboBox2.SelectedItem.ToString());
                    ti.Supp_ID = int.Parse(comboBox3.SelectedItem.ToString());
                    ti.Item_Code = int.Parse(comboBox4.SelectedItem.ToString());
                    ti.Item_Total = int.Parse(textBox6.Text);
                    ti.Production_Date = dateTimePicker1.Value;
                    ti.Expiration_Date = dateTimePicker2.Value;

                    //STORE_ITEM TABLE
                    var x = (from old in Ent.Store_Item
                             where old.Store_ID == ti.From_ID && old.Item_Code == ti.Item_Code
                             select old.Item_Total).FirstOrDefault();
                    x = int.Parse(textBox5.Text) - int.Parse(textBox6.Text);

                    var y = (from neww in Ent.Store_Item
                             where neww.Store_ID == ti.To_ID && neww.Item_Code == ti.Item_Code
                             select neww.Item_Total).FirstOrDefault();
                    if (y != null)
                    {
                        y = int.Parse(textBox5.Text) + int.Parse(textBox6.Text);
                    }
                    else
                    {
                        si.Store_ID = int.Parse(ti.To_ID.ToString());
                        si.Item_Code = int.Parse(ti.Item_Code.ToString());
                        si.Item_Total = int.Parse(textBox6.Text);
                        si.Production_Date = dateTimePicker1.Value;
                        si.Expiration_Date = dateTimePicker2.Value;
                    }

                    Ent.SaveChanges();
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
