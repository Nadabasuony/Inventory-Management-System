using System;
using System.Drawing;
using System.Windows.Forms;

namespace DP_Project
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
			button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button7.Enabled = button8.Enabled = false;
			button1.BackColor = Color.FromArgb(113, 191, 245);
			button6.Visible = true;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			button1.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button7.Enabled = button8.Enabled = false;
			button2.BackColor = Color.FromArgb(113, 191, 245);
			button6.Visible = true;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			button1.Enabled = button2.Enabled = button4.Enabled = button5.Enabled = button7.Enabled = button8.Enabled = false;
			button3.BackColor = Color.FromArgb(113, 191, 245);
			button6.Visible = true;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			button1.Enabled = button2.Enabled = button3.Enabled = button5.Enabled = button7.Enabled = button8.Enabled = false;
			button4.BackColor = Color.FromArgb(113, 191, 245);
			button6.Visible = true;
		}

		private void button5_Click(object sender, EventArgs e)
		{
			button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button7.Enabled = button8.Enabled = false;
			button5.BackColor = Color.FromArgb(113, 191, 245);
			button6.Visible = true;
		}

		private void button7_Click(object sender, EventArgs e)
		{
			button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button8.Enabled = false;
			button7.BackColor = Color.FromArgb(113, 191, 245);
			button6.Visible = true;
		}

		private void button8_Click(object sender, EventArgs e)
		{
			button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button7.Enabled = false;
			button8.BackColor = Color.FromArgb(113, 191, 245);
			button6.Visible = true;
		}
		private void button6_Click(object sender, EventArgs e)
		{
			if (button1.Enabled == true)
			{
				Form2 form2 = new Form2();
				this.Hide();
				form2.ShowDialog();
				this.Close();
			}
			else if (button2.Enabled == true)
			{
				Form3 form3 = new Form3();
				this.Hide();
				form3.ShowDialog();
				this.Close();
			}
			else if (button3.Enabled == true)
			{
				Form4 form4 = new Form4();
				this.Hide();
				form4.ShowDialog();
				this.Close();
			}
			else if (button4.Enabled == true)
			{
				Form5 form5 = new Form5();
				this.Hide();
				form5.ShowDialog();
				this.Close();
			}
			else if (button5.Enabled == true)
			{
				Form6 form6 = new Form6();
				this.Hide();
				form6.ShowDialog();
				this.Close();
			}
			else if (button7.Enabled == true)
			{
				Form7 form7 = new Form7();
				this.Hide();
				form7.ShowDialog();
				this.Close();
			}
			else if (button8.Enabled == true)
			{
				Form8 form8 = new Form8();
				this.Hide();
				form8.ShowDialog();
				this.Close();
			}
		}
	}
}
