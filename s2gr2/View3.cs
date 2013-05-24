using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Practices.Prism.Events;
using common;

namespace s2gr2
{
	public partial class View3 : UserControl
	{
		private readonly IMessageBoxService _messageBoxService;
		private readonly IEnumerable<IDataService<Person>> _pDataServices;
		private readonly IEventAggregator _eventAggregator;
		private readonly IAsyncService _asyncService;

		public View3(IMessageBoxService messageBoxService, IAsyncService asyncService,
			IEnumerable<IDataService<Person>> pDataService, IEventAggregator eventAggregator)
		{
			_messageBoxService = messageBoxService;
			_pDataServices = pDataService;
			_eventAggregator = eventAggregator;
			_asyncService = asyncService;
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			new Thread(
				o =>
					{
						var sc = (SynchronizationContext)o;

						Thread.Sleep(1000);
						sc.Post(o2 => label1.Text = "1", null);
						Thread.Sleep(1000);
						sc.Post(o2 => label1.Text = "2", null);
						Thread.Sleep(1000);
						sc.Post(o2 => label1.Text = "3", null);
					}
			).Start(SynchronizationContext.Current);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			_asyncService.PerformAsyncAction(
				() =>
					{
						Thread.Sleep(1000);
						return true;
					},
				flag => label1.Text = "1"
			);
		}

		private void button3_Click(object sender, EventArgs eargs)
		{
			_asyncService.PerformAsyncAction(
				() => _pDataServices.SelectMany(e => e.GetData()).ToList(),
				data =>
					{
						dataGridView1.DataSource = data;
						_eventAggregator.GetEvent<DataArrivedEvent>()
							.Publish(data);
					}
			);
		}
	}
}
