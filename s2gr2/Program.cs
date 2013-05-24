using System;
using System.Windows.Forms;
using CommonServiceLocator.NinjectAdapter;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using common;
using Microsoft.Practices.Prism.Events;

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
            //kernel.Bind<IAsyncService>().To<AsyncService>().InSingletonScope();
            kernel.Bind<IDataService<Person>>().To<PeopleDataService>();
            kernel.Bind<IDataService<Person>>().To<PeopleDataService2>();

            //Application.Run(kernel.Get<Shell>());
            Application.Run(ServiceLocator.Current.GetInstance<Shell>());
        }
    }
}
