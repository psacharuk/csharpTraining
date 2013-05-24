using common;

namespace s2gr2
{
	class FancyMessageBoxService : IMessageBoxService
	{
		public void ShowMessage(string message, EMessageType type = EMessageType.Alert)
		{
			var frm = new MessageBoxForm(message, type);
			frm.ShowDialog();
		}
	}
}