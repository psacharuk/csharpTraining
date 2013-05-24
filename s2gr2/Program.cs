using System;
using System.Windows.Forms;

namespace s2gr2
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Shell(new TabbedViewProvider()));
		}
	}
}
