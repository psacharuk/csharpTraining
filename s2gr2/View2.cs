using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using common;

namespace s2gr2
{
	public partial class View2 : UserControl
	{
		private readonly IMessageBoxService _messageBoxService;

		public View2(IMessageBoxService messageBoxService)
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

		// 1 1 2 3 5 8 13 21 ...
		decimal fib(decimal x)
		{
			if (x == 1 || x == 2)
				return 1;
			return fib(x - 1) + fib(x - 2);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			var t1 = new Thread(Start);
			t1.Start();
			t1.Join();
		}

		private void Start()
		{
			label1.Text = fib(20).ToString();
		}

		class ThreadData
		{
			public int Val { get; set; }
		}

        private void button2_Click_1(object sender, EventArgs e)
        {
            var sc = new DelegateCallbackSampaleClass();
            sc.DoSomething();
            _messageBoxService.ShowMessage(sc.DoOtherThing(2).ToString());
        }

		//private void button5_Click(object sender, EventArgs e)
		//{
		//    var t1 = new Thread(Start);
		//    var t2 = new Thread(Start);
		//    var data = new ThreadData(){Val = 0};
		//    t1.Start(data);
		//    t2.Start(data);
		//    t1.Join();
		//    t2.Join();
		//    label1.Text = data.Val.ToString();
		//}

		//object _syncObject = new object();
		//private void Start(object o)
		//{
		//    var data = (ThreadData)o;
		//    for (int i = 0; i < 100000; ++i)
		//    {
		//        lock(_syncObject)
		//            ++data.Val;
		//    }
		//}
	}
}
