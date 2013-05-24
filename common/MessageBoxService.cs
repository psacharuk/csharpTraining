using System.Windows.Forms;

namespace common
{
	class MessageBoxService : IMessageBoxService
	{
		public void ShowMessage(string message, EMessageType type = EMessageType.Alert)
		{
			MessageBox.Show(message);
		}

		public bool Confirm(string message)
		{
			throw new System.NotImplementedException();
		}

		public bool Prompt<T>(PromptInfo<T> info)
		{
			throw new System.NotImplementedException();
		}
	}
}