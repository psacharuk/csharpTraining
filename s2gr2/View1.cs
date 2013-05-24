using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using common;

namespace s2gr2
{
	public partial class View1 : UserControl
	{
		private readonly IMessageBoxService _messageBoxService;

		public View1(IMessageBoxService messageBoxService)
		{
			_messageBoxService = messageBoxService;
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
			var info = new PromptInfo<string>("Podaj swój numer karty kredytowej");
			if(_messageBoxService.Prompt(info))
			{
				if(_messageBoxService.Confirm("czy potwierdzasz swój nr karty"))
				{
					_messageBoxService.ShowMessage("a");
				}
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			var info = new PromptInfo<int>("Podaj swój wiek");
			if (_messageBoxService.Prompt(info))
			{
				if (_messageBoxService.Confirm(string.Format("czy potwierdzasz swój wiek: {0}", info.ReturnValue)))
				{
					_messageBoxService.ShowMessage("a");
				}
			}
		}
	}
}
