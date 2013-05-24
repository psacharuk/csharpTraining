using System.Collections.Generic;

namespace s2gr2
{
	class TabbedViewProvider : IIViewProvider
	{
		public EProjectionType ProjectionType
		{
			get { return EProjectionType.Tabbed; }
		}

		public IEnumerable<ViewItemDescriptor> GetViews()
		{
			var lst = new List<ViewItemDescriptor>();

			lst.Add(
				new ViewItemDescriptor()
					{
						Header = "View1",
						View = typeof(View1)
					}
				);

			lst.Add(
				new ViewItemDescriptor()
					{
						Header = "links",
						View = typeof(LinkView)
					}
				);

			lst.Add(
				new ViewItemDescriptor()
				{
					Header = "SMILE",
					View = typeof(SmileView)
				}
				);

			lst.Add(
				new ViewItemDescriptor()
				{
					Header = "Notepad",
					View = typeof(NotepadView)
				}
			);

			lst.Add(
				new ViewItemDescriptor()
				{
					Header = "Pliki",
					View = typeof(FileView)
				}
			);

			lst.Add(
				new ViewItemDescriptor()
				{
					Header = "View2",
					View = typeof(View2)
				}
			);

			lst.Add(
				new ViewItemDescriptor()
				{
					Header = "View3",
					View = typeof(View3)
				}
			);

			lst.Add(
				new ViewItemDescriptor()
				{
					Header = "Firmy",
					View = typeof(CompanyView)
				}
			);

			return lst;
		}
	}
}