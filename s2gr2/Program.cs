using System;
using System.Windows.Forms;
using CommonServiceLocator.NinjectAdapter;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using common;

namespace s2gr2
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			IKernel ninject = new StandardKernel();
			var locator = new NinjectServiceLocator(ninject);
			ServiceLocator.SetLocatorProvider(() => locator);

			var kernel = ServiceLocator.Current.GetInstance<IKernel>();
			kernel.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
			kernel.Bind<IMessageBoxService>().To<FancyMessageBoxService>();
			kernel.Bind<IIViewProvider>().To<TabbedViewProvider>();
			kernel.Bind<IAsyncService>().To<AsyncService>();
			kernel.Bind<IDataService<Person>>().To<PeopleDataService>();
			kernel.Bind<IDataService<Person>>().To<PeopleDataService2>();
            kernel.Bind<IDataService<Company>>().To<CompanyDataService>();

			//Application.Run(kernel.Get<Shell>());
			Application.Run(ServiceLocator.Current.GetInstance<Shell>());
		}
	}
}
