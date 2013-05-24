using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace s2gr2
{

    public delegate void DoSomethingDelegate();
    public delegate double DoOtherThingDelegate(double x);

    class DelegateCallbackSampaleClass
    {
        private DoSomethingDelegate _doSomething;
        private DoOtherThingDelegate _doOtherThing;

        public DelegateCallbackSampaleClass(DoSomethingDelegate dsa, DoOtherThingDelegate doa)
        {
            _doOtherThing = dsa;
            _doSomething = doa;
        }

        public void DoSomething()
        {
            MessageBox.Show("sialalala");
        }
        public double DoOtherThing(double x)
        {
            return _doOtherThing.Invoke(x);
            //MessageBox.Show(x.ToString());
            //return 2 * x;
        }

        private void DoSomethingAction()
        {
            MessageBox.Show("sialalala");
        }

        public double DoOtherThingAction(double x)
        {
            MessageBox.Show(x.ToString());
            return 3 * x;
        }
    }
}
