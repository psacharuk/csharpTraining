using System.Windows.Forms;
using common;

namespace s2gr2
{
	class MessageBoxService : IMessageBoxService
	{
		public void ShowMessage(string message, EMessageType type = EMessageType.Alert)
		{
			MessageBox.Show(message);
		}


        public bool Confirm(string message)
        {
            return false;
        }
    }
}