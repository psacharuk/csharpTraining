using System;
using System.Windows.Forms;
using common;

namespace s2gr2
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			ServiceLocator.Instance.Register<IMessageBoxService>(new FancyMessageBoxService());
			ServiceLocator.Instance.Register<IIViewProvider>(new TabbedViewProvider());
			ServiceLocator.Instance.Register(new Shell(ServiceLocator.Instance.Resolve<IIViewProvider>()));

			Application.Run(ServiceLocator.Instance.Resolve<Shell>());
		}
	}
}
