using System;
using System.Threading;

namespace s2gr2
{
    class AsyncService : IAsyncService
    {
        private readonly SynchronizationContext _synchronizationContext;

        public AsyncService()
        {
            _synchronizationContext = SynchronizationContext.Current;
        }

        public void PerformAsyncAction<TData>(Func<TData> fun, Action<TData> callback)
		{
            ThreadPool.QueueUserWorkItem(o =>
                {
                    var data = fun();
                    var sc = (SynchronizationContext) o;
                    sc.Post(o2 => callback(data), null);
                }, _synchronizationContext);
		}
    }
}