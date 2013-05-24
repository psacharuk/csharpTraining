using System.Windows.Forms;

namespace common
{
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

		public bool Prompt(PromptInfo info)
		{
			using (var frm = new PromptForm(info.Message))
			{
				frm.PromptValue = "wprowadü tekst";
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