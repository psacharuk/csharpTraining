using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using common;

namespace s2gr2
{
	public partial class View3 : UserControl
	{
		private readonly IMessageBoxService _messageBoxService;
		private readonly IAsyncService _asyncService = new AsyncService();


		public View3(IMessageBoxService messageBoxService)
		{
			_messageBoxService = messageBoxService;
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

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _pDataService.GetData();
        }
	}

    interface IDataService<TData>
    {
        IEnumerable<TData> GetData();
    }
    class PepoleDataService : IDataService<Person>
    {
        public IEnumerable<Person> GetData()
        {
            var rand = new Random();
            var lst = new List<Person>();

            for (int i = 0; i<100; i++)
            {
                lst.Add(
                    new Person()
                    {
                        Name = string.Format("name {0}", i),
                        SurName = string.Format("surname {0}", i)
                    }
                    );
            }
            return lst;
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}
