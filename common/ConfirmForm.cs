using System;
using System.Windows.Forms;

namespace common
{
	public partial class ConfirmForm : Form
	{
		public ConfirmForm(string message)
		{
			InitializeComponent();

			label1.Text = message;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Yes;
			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.No;
			Close();
		}
	}
}
