using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
			_messageBoxService.ShowMessage("hello windows forms!", EMessageType.Alert);
		}
	}
}
