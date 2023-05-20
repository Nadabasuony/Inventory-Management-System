using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DP_Project
{
    public partial class Form6 : Form
    {
        TradingCompanyEntities Ent = new TradingCompanyEntities();
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.FromArgb(34, 140, 184)), new Rectangle(0, 0, Width, 80));
        }

        public Form6()
        {
            InitializeComponent();
            textBox2.Visible = false;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            foreach (Permission pe in Ent.Permissions)
            {
                comboBox1.Items.Add(pe.Permission_ID);
            }

            comboBox2.Items.Add("Import");
            comboBox2.Items.Add("Export");
            
            foreach (Store st in Ent.Stores)
            {
                comboBox3.Items.Add(st.Store_ID);
            }

            foreach (Supplier su in Ent.Suppliers) 
            {
                comboBox4.Items.Add(su.Supp_ID);
            }

            foreach (Item it in Ent.Items) 
            {
                comboBox5.Items.Add(it.Item_Code);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id1 = int.Parse(comboBox1.Text);
            Permission pi = Ent.Permissions.Find(id1);
            comboBox2.SelectedItem = pi.Permission_Type;

            int id2 = pi.Store_ID;
            Store st = Ent.Stores.Find(id2);
            comboBox3.SelectedItem = st.Store_ID;
            textBox6.Text = st.Store_Name;

            int id3 = pi.Supp_ID;
            Supplier su = Ent.Suppliers.Find(id3);
            comboBox4.SelectedItem = su.Supp_ID;
            textBox7.Text = su.Supp_Name;

            int id4 = pi.Permission_ID;
            var idd = (from s in Ent.Permissioned_Item
                       where s.Permission_ID == id4
                       select s).FirstOrDefault(); 
            int id5 = int.Parse(idd.Item_Code.ToString());
            Item it = Ent.Items.Find(id5);
            comboBox5.SelectedItem = it.Item_Code;
            textBox8.Text = it.Item_Name;

            int id6 = int.Parse(comboBox3.SelectedItem.ToString());
            int id7 = int.Parse(comboBox5.SelectedItem.ToString());

            textBox5.Text = idd.Item_Total.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Store_Item si = new Store_Item();
            Permission pe = new Permission();
            Permissioned_Item pi = new Permissioned_Item();

            if (textBox1.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && comboBox2.SelectedItem != null)
            {
                //PERMISSION TABLE
                pe.Permission_Date = dateTimePicker1.Value;
                pe.Supp_ID = int.Parse(comboBox4.SelectedItem.ToString());
                pe.Store_ID = int.Parse(comboBox3.SelectedItem.ToString());
                pe.Permission_Type = comboBox2.SelectedItem.ToString();
                Ent.Permissions.Add(pe);

                //PERMISSION_ITEM TABLE
                pi.Permission_ID = pe.Permission_ID;
                pi.Item_Total = int.Parse(textBox1.Text);
                pi.Item_Code = int.Parse(comboBox5.SelectedItem.ToString());
                Ent.Permissioned_Item.Add(pi);

                if (comboBox2.SelectedIndex == 0) //import
                {
                    //STORE_ITEM TABLE
                    if (textBox5.Text != "") //existing store and item value
                    {
                        //int n1 = int.Parse(comboBox3.SelectedItem.ToString()); //store
                        //int n2 = int.Parse(comboBox5.SelectedItem.ToString()); //item
                        //int nn1 = int.Parse(textBox1.Text);
                        //int nn2 = int.Parse(textBox5.Text);
                        //int total = nn1 + nn2;
                        si.Item_Total = int.Parse(textBox1.Text) + int.Parse(textBox5.Text);
                        si.Production_Date = dateTimePicker2.Value;
                        si.Expiration_Date = dateTimePicker3.Value;
                        Ent.SaveChanges();
                        MessageBox.Show("Added Successfully.", "Done!");
                    }
                    else //new store and item value
                    {
                        si.Store_ID = int.Parse(comboBox3.SelectedItem.ToString());
                        si.Item_Code = int.Parse(comboBox5.SelectedItem.ToString());
                        si.Production_Date = dateTimePicker2.Value;
                        si.Expiration_Date = dateTimePicker3.Value;
                        si.Item_Total = int.Parse(textBox1.Text);
                        Ent.Store_Item.Add(si);
                        MessageBox.Show("Added Successfully.", "Done!");
                    }
                }
                else //export
                {
                    var ids = (from s in Ent.Store_Item
                              where s.Item_Code == pi.Item_Code && s.Store_ID == pe.Store_ID
                              select s).FirstOrDefault();
                    if (textBox5.Text != "") //existing store and item value more than 0
                    {
                        //int n1 = int.Parse(comboBox3.SelectedItem.ToString()); //store
                        //int n2 = int.Parse(comboBox5.SelectedItem.ToString()); //item
                        //int nn1 = int.Parse(textBox1.Text);
                        //int nn2 = int.Parse(textBox5.Text);
                        //int total = nn2 - nn1;
                        si.Item_Total = int.Parse(textBox5.Text) - int.Parse(textBox1.Text);
                        si.Production_Date = dateTimePicker2.Value;
                        si.Expiration_Date = dateTimePicker3.Value;
                        Ent.SaveChanges();
                        MessageBox.Show("Added Successfully.", "Done!");
                    }
                    else //existing store and item = 0
                    {
                        MessageBox.Show("There is no item to be exported.", "Warning!");
                    }
                }
                Ent.SaveChanges();
                comboBox1.Items.Clear();
                foreach (Permission pet in Ent.Permissions)
                {
                    comboBox1.Items.Add(pet.Permission_ID);
                }
            }
            else
            {
                MessageBox.Show("Please fill all the data.", "Warning!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Permission pe = Ent.Permissions.Find(int.Parse(comboBox1.SelectedItem.ToString()));
            Permissioned_Item pi = new Permissioned_Item();
            Store_Item si = new Store_Item();

            if (pe != null)
            {
                if (textBox1.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && comboBox2.SelectedItem != null)
                {
                    //PERMISSION TABLE
                    pe.Permission_Date = dateTimePicker1.Value;
                    pe.Supp_ID = int.Parse(comboBox4.SelectedItem.ToString());
                    pe.Store_ID = si.Store_ID = int.Parse(comboBox3.SelectedItem.ToString());
                    pe.Permission_Type = comboBox2.SelectedItem.ToString();

                    //PERMISSION_ITEM TABLE
                    pi.Permission_ID = pe.Permission_ID;
                    pi.Item_Total = int.Parse(textBox1.Text);
                    pi.Item_Code = si.Item_Code = int.Parse(comboBox5.SelectedItem.ToString());

                    //STORE_ITEM TABLE
                    //si.Store_ID = int.Parse(comboBox3.SelectedItem.ToString());
                    //si.Item_Code = int.Parse(comboBox5.SelectedItem.ToString());
                    si.Production_Date = dateTimePicker2.Value;
                    si.Expiration_Date = dateTimePicker3.Value;
                    si.Item_Total = int.Parse(textBox1.Text);

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

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ids1 = int.Parse(comboBox3.SelectedItem.ToString());
            Store st = Ent.Stores.Find(ids1);
            int idss1 = st.Store_ID;

            int ids = int.Parse(comboBox5.SelectedItem.ToString());
            Item it = Ent.Items.Find(ids);
            int idss = it.Item_Code;
 
            var si = (from s in Ent.Store_Item
                      where s.Item_Code == idss && s.Store_ID == idss1
                      select s.Item_Total).FirstOrDefault();
            textBox5.Text = si.ToString();
            textBox8.Text = it.Item_Name;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ids = int.Parse(comboBox4.SelectedItem.ToString());
            Supplier su = Ent.Suppliers.Find(ids);
            textBox7.Text = su.Supp_Name;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ids = int.Parse(comboBox3.SelectedItem.ToString());
            Store st = Ent.Stores.Find(ids);
            textBox6.Text = st.Store_Name;
        }
    }
}
