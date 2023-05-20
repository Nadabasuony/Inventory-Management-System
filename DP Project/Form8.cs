using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DP_Project
{
	public partial class Form8 : Form
	{
		TradingCompanyEntities Ent = new TradingCompanyEntities();

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = this.CreateGraphics();
			g.FillRectangle(new SolidBrush(Color.FromArgb(34, 140, 184)), new Rectangle(0, 0, Width, 30));
		}

		public Form8()
		{
			InitializeComponent();
		}

		private void Form8_Load(object sender, EventArgs e)
		{
			foreach (Store st in Ent.Stores)
			{
				comboBox1.Items.Add(st.Store_ID);
				checkedListBox1.Items.Add(st.Store_ID);
			}
			foreach (Item it in Ent.Items)
			{
				comboBox2.Items.Add(it.Item_Code);
			}
			comboBox3.Items.Add("Day");
			comboBox3.Items.Add("Month");
			comboBox3.Items.Add("Year");
			comboBox4.Items.Add("Day");
			comboBox4.Items.Add("Month");
			comboBox4.Items.Add("Year");
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
			listBox1.Items.Clear();
			listBox2.Items.Clear();
			listBox3.Items.Clear();
			int id = int.Parse(comboBox1.SelectedItem.ToString());
			Store sto = Ent.Stores.Find(id);
			var ran1 = (from st in Ent.Stores
						join si in Ent.Store_Item on st.Store_ID equals si.Store_ID
						join it in Ent.Items on si.Item_Code equals it.Item_Code
						where st.Store_ID == id
						select it);

			var ran2 = (from st in Ent.Stores
						join si in Ent.Store_Item on st.Store_ID equals si.Store_ID
						join it in Ent.Items on si.Item_Code equals it.Item_Code
						where st.Store_ID == id
						select si);

			listBox1.Items.Add($"{sto.Store_Name}");
			foreach (var r1 in ran1)
			{
				listBox2.Items.Add($"{r1.Item_Name}");
			}
			foreach (var r2 in ran2)
			{
				listBox3.Items.Add($"{r2.Item_Total}");
			}
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			listBox4.Items.Clear();
			listBox5.Items.Clear();
			listBox6.Items.Clear();
			int id = int.Parse(comboBox2.SelectedItem.ToString());
			Item ite = Ent.Items.Find(id);
			var ran1 = (from st in Ent.Stores
						join si in Ent.Store_Item on st.Store_ID equals si.Store_ID
						join it in Ent.Items on si.Item_Code equals it.Item_Code
						where it.Item_Code == id
						select st);
			var ran2 = (from st in Ent.Stores
						join si in Ent.Store_Item on st.Store_ID equals si.Store_ID
						join it in Ent.Items on si.Item_Code equals it.Item_Code
						where it.Item_Code == id
						select si);

			listBox4.Items.Add($"{ite.Item_Name}");
			foreach (var r1 in ran1)
			{
				listBox5.Items.Add($"{r1.Store_Name}");
			}
			foreach (var r2 in ran2)
			{
				listBox6.Items.Add($"{r2.Item_Total}");
			}
		}

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			Changing();
		}

		private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
		{
			Changing();
		}

		private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			Changing();
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			Amount1();
		}

		private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
		{
			Amount1();
		}

		private void numericUpDown2_ValueChanged(object sender, EventArgs e)
		{
			Amount2();
		}

		private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
		{
			Amount2();
		}

		private void Changing()
		{
			if (checkedListBox1.CheckedItems.Count > 0)
			{
				listBox7.Items.Clear();
				listBox8.Items.Clear();
				for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
				{
					var d1 = dateTimePicker1.Value;
					var d2 = dateTimePicker2.Value;
					var x = int.Parse(checkedListBox1.CheckedItems[i].ToString());
					var ran1 = (from st in Ent.Stores
								join si in Ent.Store_Item on st.Store_ID equals si.Store_ID
								join it in Ent.Items on si.Item_Code equals it.Item_Code
								join ti in Ent.Transfer_Item on si.Item_Code equals ti.Item_Code
								where st.Store_ID == x && ti.Production_Date >= d1 && ti.Expiration_Date <= d2
								select it);
					foreach (var r1 in ran1)
					{
						listBox7.Items.Add(r1.Item_Name);
					}
					var ran2 = (from st in Ent.Stores
								join si in Ent.Store_Item on st.Store_ID equals si.Store_ID
								join it in Ent.Items on si.Item_Code equals it.Item_Code
								join ti in Ent.Transfer_Item on si.Item_Code equals ti.Item_Code
								where st.Store_ID == x && ti.Production_Date >= d1 && ti.Expiration_Date <= d2
								select st);
					foreach (var r2 in ran2)
					{
						listBox8.Items.Add(r2.Store_Name);
					}
				}
			}
		}

		private void Amount1()
		{
			int i = 0;
			Store_Item si = new Store_Item();
			listBox9.Items.Clear();
			listBox10.Items.Clear();
			DateTime now = DateTime.Now;
			if (numericUpDown1.Value > 0 && comboBox3.SelectedIndex != -1)
			{
				int num = int.Parse(numericUpDown1.Value.ToString());
				if (comboBox3.SelectedIndex == 0)
				{
					TimeSpan total = TimeSpan.Parse(num.ToString());
					foreach (var item in Ent.Store_Item)
					{
						TimeSpan? x = TimeSpan.Parse(0.ToString());
						TimeSpan? xx = (now - item.Production_Date) - total;
						if (x < xx && xx >= total)
						{
							i++;
							listBox9.Items.Add(i + ") " + item.Item.Item_Name);
							listBox10.Items.Add(i + ") " + item.Store.Store_Name);
						}
					}
				}
				else if (comboBox3.SelectedIndex == 1)
				{
					TimeSpan total = TimeSpan.Parse((num * 30).ToString());
					foreach (var item in Ent.Store_Item)
					{
						TimeSpan? x = TimeSpan.Parse(0.ToString());
						TimeSpan? xx = (now - item.Production_Date) - total;
						if (x < xx && xx >= total)
						{
							i++;
							listBox9.Items.Add(i + ") " + item.Item.Item_Name);
							listBox10.Items.Add(i + ") " + item.Store.Store_Name);
						}
					}
				}
				else
				{
					TimeSpan total = TimeSpan.Parse((num * 365).ToString());
					foreach (var item in Ent.Store_Item)
					{
						TimeSpan? x = TimeSpan.Parse(0.ToString());
						TimeSpan? xx = (now - item.Production_Date);
						if (x < xx && xx >= total)
						{
							i++;
							listBox9.Items.Add(i + ") " + item.Item.Item_Name);
							listBox10.Items.Add(i + ") " + item.Store.Store_Name);
						}
					}
				}
			}
		}

		private void Amount2()
		{
			int i = 0;
			Store_Item si = new Store_Item();
			listBox11.Items.Clear();
			listBox12.Items.Clear();
			DateTime now = DateTime.Now;
			if (numericUpDown2.Value > 0 && comboBox4.SelectedIndex != -1)
			{
				int num = int.Parse(numericUpDown2.Value.ToString());
				if (comboBox4.SelectedIndex == 0)
				{
					TimeSpan total = TimeSpan.Parse(num.ToString());
					foreach (var item in Ent.Store_Item)
					{
						TimeSpan? x = TimeSpan.Parse(0.ToString());
						TimeSpan? xx = (item.Expiration_Date - now);
						if (x < xx && xx <= total)
						{
							i++;
							listBox11.Items.Add(i + ") " + item.Item.Item_Name);
							listBox12.Items.Add(i + ") " + item.Store.Store_Name);
						}
					}
				}
				else if (comboBox4.SelectedIndex == 1)
				{
					TimeSpan total = TimeSpan.Parse((num * 30).ToString());
					foreach (var item in Ent.Store_Item)
					{
						TimeSpan? x = TimeSpan.Parse(0.ToString());
						TimeSpan? xx = (item.Expiration_Date - now);
						if (x < xx && xx <= total)
						{
							i++;
							listBox11.Items.Add(i + ") " + item.Item.Item_Name);
							listBox12.Items.Add(i + ") " + item.Store.Store_Name);
						}
					}
				}
				else
				{
					TimeSpan total = TimeSpan.Parse((num * 365).ToString());
					foreach (var item in Ent.Store_Item)
					{
						TimeSpan? x = TimeSpan.Parse(0.ToString());
						TimeSpan? xx = (item.Expiration_Date - now);
						if (xx > x && xx <= total)
						{
							i++;
							listBox11.Items.Add(i + ") " + item.Item.Item_Name);
							listBox12.Items.Add(i + ") " + item.Store.Store_Name);
						}
					}
				}
			}
		}
	}
}
