using System.Collections.Generic;
using common;

namespace s2gr2
{
	class TabbedViewProvider : IIViewProvider
	{
		public TabbedViewProvider()
		{
			ServiceLocator.Instance.Register(new View1(ServiceLocator.Instance.Resolve<IMessageBoxService>()));
			ServiceLocator.Instance.Register(new LinkView());
			ServiceLocator.Instance.Register(new SmileView());
			ServiceLocator.Instance.Register(new NotepadView());
		}

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
						View = ServiceLocator.Instance.Resolve<View1>()
					}
				);

			lst.Add(
				new ViewItemDescriptor()
					{
						Header = "links",
						View = ServiceLocator.Instance.Resolve<LinkView>()
					}
				);

			lst.Add(
				new ViewItemDescriptor()
				{
					Header = "SMILE",
					View = ServiceLocator.Instance.Resolve<SmileView>()
				}
				);

			lst.Add(
				new ViewItemDescriptor()
				{
					Header = "Notepad",
					View = ServiceLocator.Instance.Resolve<NotepadView>()
				}
			);

			return lst;
		}
	}
}