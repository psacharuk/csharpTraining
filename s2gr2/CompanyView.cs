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
	public partial class CompanyView : UserControl
	{
		private readonly IMessageBoxService _messageBoxService;
		private readonly IAsyncService _asyncService;
		private readonly IDataService<Company> _companyDataService;

		private IEnumerable<Company> _data;

		public CompanyView(IMessageBoxService messageBoxService, IAsyncService asyncService,
			IDataService<Company> companyDataService)
		{
			_messageBoxService = messageBoxService;
			_asyncService = asyncService;
			_companyDataService = companyDataService;
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var col1 = _companyDataService.GetData().Take(100);
			_messageBoxService.ShowMessage(
				col1.First().GetHashCode().ToString()
			);
			_messageBoxService.ShowMessage(
				col1.First().GetHashCode().ToString()
			);

			var col2 = _companyDataService.GetData().Take(100).ToList();
			_messageBoxService.ShowMessage(
				col2.First().GetHashCode().ToString()
			);
			_messageBoxService.ShowMessage(
				col2.First().GetHashCode().ToString()
			);

			_asyncService.PerformAsyncAction(
				() =>
				{
					_data = _companyDataService.GetData().Take(100).ToList();
					return _data;
				},
				data => dataGridView1.DataSource = data
			);
		}

		private void button2_Click(object sender, EventArgs eargs)
		{
			var fc1 = _data.First();//mozliwy wyjątek
			var fc = _data.FirstOrDefault();
			if (fc != null)
			{

			}

			//_data.Single()
			//_data.SingleOrDefault()

			var df1 = _data.First(e => e.Name == "company1");

			dataGridView1.DataSource = _data.Where(e => ((e.Nip % 10) < 5))
				.OrderBy(e => e.Name).ThenBy(e => e.Nip).ThenBy(e => e.Regon)
				.ToList();
		}

		private void button3_Click(object sender, EventArgs args)
		{
			dataGridView1.DataSource = _data.Select(e => new { Nip_firmy = e.Nip }).ToList();
			//_data.Max(e=>e.Nip)
			//_data.Sum(e=>e.Nip)

		}

		private void button4_Click(object sender, EventArgs args)
		{
			dataGridView1.DataSource = _data.GroupBy(e => e.Nip % 10)
				.OrderBy(e => e.Key)
				.SelectMany(e => e.OrderBy(f => f.Name))
				.Select(e => new { e.Nip, e.Name }).ToList();
		}
	}
}
