using System.Collections.Generic;
using common;

namespace s2gr2
{
	class ModalViewProvider : IIViewProvider
	{
		public EProjectionType ProjectionType
		{
			get { return EProjectionType.Modal; }
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

			return lst;
		}
	}
}