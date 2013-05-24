using System;
using System.Windows.Forms;
using common;

namespace s2gr2
{
	public partial class Form1 : Form
	{
		private readonly IMessageBoxService _messageBoxService = new FancyMessageBoxService();

		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			_messageBoxService.ShowMessage("hello windows forms!");
		}

		private void button2_Click(object sender, EventArgs e)
		{
			_messageBoxService.ShowMessage("hello windows forms!", EMessageType.Error);
		}

        private void button3_Click(object sender, EventArgs e)
        {
            new LinkForm().ShowDialog();
        }
	}
}
