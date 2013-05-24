using System;

namespace s2gr2
{
	public interface IAsyncService
	{
		void PerformAsyncAction<TData>(Func<TData> fun, Action<TData> callback);
	}
}