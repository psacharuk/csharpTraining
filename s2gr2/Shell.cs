using System.Windows.Forms;
using Microsoft.Practices.ServiceLocation;

namespace s2gr2
{
	public partial class Shell : Form
	{
		public Shell(IIViewProvider viewProvider)
		{
			InitializeComponent();

			if (viewProvider.ProjectionType == EProjectionType.Tabbed)
			{
				menuStrip1.Visible = false;

				foreach (var vd in viewProvider.GetViews())
				{
					//var kernel = ServiceLocator.Current.GetInstance<IKernel>();
					//var view = (Control) kernel.Get(vd.View);

					var view = (Control)ServiceLocator.Current.GetInstance(vd.View);
					view.Dock = DockStyle.Fill;
					var tp = new TabPage(vd.Header);
					tp.Controls.Add(view);
					tabControl1.TabPages.Add(tp);
				}
			}
			else if (viewProvider.ProjectionType == EProjectionType.Modal)
			{
				tabControl1.Visible = false;

				foreach (var vd in viewProvider.GetViews())
				{
					var item = new ToolStripMenuItem(vd.Header, null, (sender, args) =>
																	{
																		var form = new Form();
																		var view = (Control)ServiceLocator.Current.GetInstance(vd.View);
																		form.Controls.Add(view);
																		form.ShowDialog();
																	});

					menuStrip1.Items.Add(item);
				}
			}
		}
	}
}
