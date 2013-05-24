using System.Collections.Generic;

namespace s2gr2
{
	public interface IDataService<out TData>
	{
		IEnumerable<TData> GetData();
	}
}