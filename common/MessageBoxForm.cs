using System;
using System.Windows.Forms;

namespace common
{
	public partial class MessageBoxForm : Form
	{
		public MessageBoxForm(string message, EMessageType type)
		{
			InitializeComponent();

			label1.Text = message;
			if (type == EMessageType.Alert)
				pictureBox1.Image = Properties.Resources.alert;
			if (type == EMessageType.Error)
				pictureBox1.Image = Properties.Resources.error;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
