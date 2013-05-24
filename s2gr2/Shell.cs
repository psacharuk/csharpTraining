using System.Windows.Forms;

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
                    vd.View.Dock = DockStyle.Fill;
					var tp = new TabPage(vd.Header);
					tp.Controls.Add(vd.View);
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
																		form.Controls.Add(vd.View);
																		form.ShowDialog();
																	});

					menuStrip1.Items.Add(item);
				}
			}
		}
	}
}
