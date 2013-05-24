using System;
using System.Windows.Forms;

namespace s2gr2
{
	//public delegate void DoSomethingDelegate();

	//public delegate double DoOtherThingDelegate(double x);

	public class DelegateCallbackSampleClass
	{
		//private DoSomethingDelegate _doSomething;
		//private DoOtherThingDelegate _doOtherThing;

		private Action _doSomething;
		private Func<double, double> _doOtherThing;

		public DelegateCallbackSampleClass()
		{
			_doSomething = DoSomethingAction;
			_doOtherThing = DoOtherThingAction;
		}

		public DelegateCallbackSampleClass(Action dsa, Func<double, double> doa)
		{
			_doSomething = dsa;
			_doOtherThing = doa;
		}

		public void DoSomething()
		{
			//_doSomething.Invoke();
			_doSomething();
		}

		public double DoOtherThing(double x)
		{
			//_doOtherThing.Invoke(x);
			return _doOtherThing(x);
		}

		private void DoSomethingAction()
		{
			MessageBox.Show("sialalalala");
		}

		private double DoOtherThingAction(double x)
		{
			MessageBox.Show(x.ToString());
			return 2 * x;
		}
	}
}