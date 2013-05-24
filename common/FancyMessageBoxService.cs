using System.Windows.Forms;

namespace common
{
	static class PromptFormFactory
	{
		public static PromptForm<T> CreatePromptForm<T>(string message)
		{
			var type = typeof (T);
			if(type==typeof(string))
			{
				return new StringPromptForm(message) as PromptForm<T>;
			}
			if (type == typeof(int))
			{
				return new IntPromptForm(message) as PromptForm<T>;
			}
			return null;
		}
	}

	public class FancyMessageBoxService : IMessageBoxService
	{
		public void ShowMessage(string message, EMessageType type = EMessageType.Alert)
		{
			using (var frm = new MessageBoxForm(message, type))
			{
				frm.ShowDialog();
			}
		}

		public bool Confirm(string message)
		{
			using (var frm = new ConfirmForm(message))
			{
				if (frm.ShowDialog() == DialogResult.Yes)
					return true;
			}
			return false;
		}

		public bool Prompt<T>(PromptInfo<T> info)
		{
			using (var frm = PromptFormFactory.CreatePromptForm<T>(info.Message))
			{
				if (frm.ShowDialog() == DialogResult.OK)
				{
					info.ReturnValue = frm.PromptValue;
					return true;
				}
			}
			return false;
		}
	}
}