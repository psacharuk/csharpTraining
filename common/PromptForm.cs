using System;
using System.Windows.Forms;

namespace common
{
	public abstract partial class PromptForm<T> : Form
	{
		public PromptForm(string message)
		{
			InitializeComponent();

			label1.Text = message;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Close();
		}

		public T PromptValue
		{
			get
			{
				try
				{
					return GetReturnValue();
				}
				catch (Exception)
				{
				}
				return default(T);
			}
			set { SetReturnValue(value); }
		}

		protected abstract T GetReturnValue();
		protected abstract void SetReturnValue(T val);
	}
}
