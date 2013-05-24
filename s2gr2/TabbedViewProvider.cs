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
						View = new View1(new FancyMessageBoxService())
					}
				);

			lst.Add(
				new ViewItemDescriptor()
					{
						Header = "links",
						View = new LinkView()
					}
				);

			lst.Add(
				new ViewItemDescriptor()
				{
					Header = "SMILE",
					View = new SmileView()
				}
				);

            lst.Add(
               new ViewItemDescriptor()
               {
                   Header = "NotepadLoader",
                   View = new NotepadLoader()
               }
               );

			return lst;
		}
	}
}