using System.Collections.Generic;

namespace s2gr2
{
	public interface IIViewProvider
	{
		EProjectionType ProjectionType { get; }

		IEnumerable<ViewItemDescriptor> GetViews();
	}
}