using System;
using System.Windows.Forms;

namespace common
{
	public partial class PromptForm : Form
	{
		public PromptForm(string message)
		{
			InitializeComponent();

			label1.Text = message;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Close();
		}

		public string PromptValue
		{
			get { return textBox1.Text; }
			set { textBox1.Text = value; }
		}
	}
}
