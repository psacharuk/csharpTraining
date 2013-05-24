using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
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

			//button6.Click += (s, e) =>
			//                    {
			//                        _messageBoxService.ShowMessage("trala");
			//                    };
			button6.Click += (s, e) => _messageBoxService.ShowMessage("trala");

			//var lst = new List<Action>();
			//for(int i=0;i<5;++i)
			//{
			//    //int d = i;
			//    lst.Add(
			//        () => _messageBoxService.ShowMessage(d.ToString())
			//    );
			//}
			//lst.ForEach(e=>e());

			//var lst = new List<_____Anonymous_lambdsa_type_XY>();
			//for (int i = 0; i < 5; ++i)
			//{
			//    lst.Add(
			//        new _____Anonymous_lambdsa_type_XY(ref i, _messageBoxService)
			//    );
			//}
			//lst.ForEach(e => e.Anonymous_function_XX());
		}

		class _____Anonymous_lambdsa_type_XY
		{
			private int _i;
			private readonly IMessageBoxService _messageBoxService;

			public _____Anonymous_lambdsa_type_XY(ref int i, IMessageBoxService messageBoxService)
			{
				_i = i;
				_messageBoxService = messageBoxService;
			}

			public void Anonymous_function_XX()
			{
				_messageBoxService.ShowMessage(_i.ToString());
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
			var t1 = new Thread(FibThreadFun);
			t1.Start();
			t1.Join();
		}

		private delegate void UpdateFibUIDelegate(decimal val, string cap);
		private void FibThreadFun()
		{
			//label1.Text = fib(30).ToString();

			//UpdateFibUIDelegate del = UpdateFibUiAction;
			UpdateFibUIDelegate del = (val, cap) => label1.Text = string.Format("{0} {1}", cap, val);
			var ret = fib(30);
			//label1.BeginInvoke(del, ret, "fib: ");
			//Action<decimal, string> act = (val, cap) => label1.Text = string.Format("{0} {1}", cap, val);
			//label1.BeginInvoke(act, ret, "fib: ");

			//label1.BeginInvoke(() => label1.Text = string.Format("{0} {1}", "trala", ret));
			label1.BeginInvoke((Action)(() => label1.Text = string.Format("{0} {1}", "trala", ret)));
		}

		//private void UpdateFibUiAction(decimal val, string cap)
		//{
		//    label1.Text = string.Format("{0} {1}", cap, val);
		//}

		class ThreadData
		{
			public int Val { get; set; }
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var t1 = new Thread(IncrementThreadFun);
			var t2 = new Thread(IncrementThreadFun);
			var data = new ThreadData() { Val = 0 };
			t1.Start(data);
			t2.Start(data);
			t1.Join();
			t2.Join();
			label1.Text = data.Val.ToString();
		}

		object _syncObject = new object();
		private void IncrementThreadFun(object o)
		{
			var data = (ThreadData)o;
			for (int i = 0; i < 100000; ++i)
			{
				lock (_syncObject)
					++data.Val;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			var sc = new DelegateCallbackSampleClass();
			sc.DoSomething();
			_messageBoxService.ShowMessage(sc.DoOtherThing(2).ToString());
		}

		private void button3_Click(object sender, EventArgs e)
		{
			var sc = new DelegateCallbackSampleClass(DoSomethingAction, DoOtherThingAction);
			sc.DoSomething();
			_messageBoxService.ShowMessage(sc.DoOtherThing(2).ToString());
		}

		private void DoSomethingAction()
		{
			MessageBox.Show("tralalala");
		}

		private double DoOtherThingAction(double x)
		{
			MessageBox.Show((2 * x).ToString());
			return 3 * x;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			var sc = new DelegateCallbackSampleClass(
				() => MessageBox.Show("tralalala"),
				d =>
					{
						MessageBox.Show((2 * d).ToString());
						return 3 * d;
					}
				);
			sc.DoSomething();
			_messageBoxService.ShowMessage(sc.DoOtherThing(2).ToString());
		}
	}
}
